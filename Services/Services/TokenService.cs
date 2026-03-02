using Data.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Models.Entities.Auth;
using Results;
using Services.DTOs;
using Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Transactions;

namespace Services.Services
{
    internal static class RefreshTokenUtils
    {
        public static string GenerateRandomToken(int byteCount = 64)
        {
            byte[] bytes = RandomNumberGenerator.GetBytes(byteCount);

            string token = Convert.ToBase64String(bytes);
            return token;
        }

        public static string HashRefreshToken(string token)
        {
            using HashAlgorithm hashAlgorithm = SHA256.Create();

            byte[] tokenBytes = Encoding.UTF8.GetBytes(token);
            byte[] hashBytes = hashAlgorithm.ComputeHash(tokenBytes);

            // Return hash as Base64 string
            string hash = Convert.ToBase64String(hashBytes);
            return hash;
        }
    }

    internal class AccessTokenUtils
    {   
        private readonly IConfiguration _configuration;

        private readonly TokenValidationParameters _tokenValidationParameters;

        public AccessTokenUtils(IConfiguration configuration)
        {
            _configuration = configuration;

            _tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true, 
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Auth:JWT:SigningKey"])),

                ValidateIssuer = true,
                ValidIssuer = _configuration["Auth:JWT:ValidIssuer"],

                ValidateAudience = true, 
                ValidateLifetime = false, // ignore expiration
                ClockSkew = TimeSpan.Zero
            };
        }
        public  JwtSecurityToken ParseAccessToken(string token)
        {
            JwtSecurityTokenHandler handeler = new JwtSecurityTokenHandler();

            JwtSecurityToken jwtToken = handeler.ReadJwtToken(token);

            return jwtToken;
        }

        public bool IsAccessTokenValid(string token)
        {
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            try
            {
        
                handler.ValidateToken(token, _tokenValidationParameters, out SecurityToken validatedToken);

              
                return validatedToken is JwtSecurityToken;
            }
            catch (Exception)
            {           
                return false;
            }
        }

    }

    internal class TokenService : ITokenService
    {
        private readonly ITokenRepository _repository;

        private readonly IAuthRepository _authRepository;

        private readonly IConfiguration _configuration;

        public TokenService(ITokenRepository repository, IAuthRepository authRepository, IConfiguration configuration)
        {
            _repository = repository;
            _authRepository = authRepository;
            _configuration = configuration;
        }

        public async Task<string> GenerateAccessTokenForUser(FoodRushIdentityUser user)
        {
            string secretKey = _configuration.GetValue<string>("Auth:JWT:SigningKey");

            SymmetricSecurityKey signKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            SigningCredentials credentials = new SigningCredentials(signKey, SecurityAlgorithms.HmacSha256);


            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.UserName)
            };

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _configuration.GetValue<string>("Auth:Token:Issuer"),
                audience: _configuration.GetValue<string>("Auth:Token:Audience"),
                claims: claims,
                notBefore: null,
                expires: DateTime.UtcNow.AddMinutes(15),
                signingCredentials: credentials
            );

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            string stringToken = handler.WriteToken(token);

            return stringToken;
        }

        public async Task<RefreshTokenWithRawDto> GenerateAndRotateRefreshTokenForUser(FoodRushIdentityUser user, string? reson = null)
        {
            RefreshTokenWithRawDto newToken = GenerateRefreshTokenForUser(user);      

            try
            {
            

                await _authRepository.RunInTransactionAsync(async () =>
                {
                    await RotateRefreshTokenForUser(user.Id, newToken.RefreshToken, reson);
                    await _repository.AddTokenAsync(newToken.RefreshToken);
                    await _repository.SaveChangesAsync();
                });               

                return newToken;
            }
            catch
            {
                // EF transaction will rollback automatically if not committed
                throw;
            }
        }

        public async Task RotateRefreshTokenForUser(string userId, RefreshToken newToken, string? reason = null)
        {
            //TODO: validate newToken
            FoodRushIdentityUser? user = await _authRepository.GetByIdAsync(userId) ??
                throw new NullReferenceException($"Could not rotate the refreshToken for userId: {userId}, the user was not found");

            RefreshToken? activeToken = user.RefreshTokens.FirstOrDefault(rt => rt.ReplacedByTokenId == null && rt.Revoked == null);

            if (activeToken != null)
            {
                activeToken.ReplacedByToken = newToken;
                activeToken.ReplacedByTokenId = newToken.Id;
                activeToken.Revoked = DateTime.UtcNow;
                activeToken.ReasonRevoked = reason;
            }
        }

        public async Task<Result<TokensDto>> RefreshAccessTokenAsync(TokensDto oldTokens)
        {
            bool isRefreshTokenValid = IsRefreshTokenValid(oldTokens.RefreshToken).Result;
            if (!isRefreshTokenValid)
            {
                return Result<TokensDto>.Fail("Invalid refresh token", Results.Enums.ResultFailureType.Authorization);
            }

            AccessTokenUtils accessTokenUtils = new AccessTokenUtils(_configuration);
            
            bool isAccessTokenValid = accessTokenUtils.IsAccessTokenValid(oldTokens.AcessToken);
            if (!isAccessTokenValid)
            {
                return Result<TokensDto>.Fail("Invalid access token", Results.Enums.ResultFailureType.Authorization);
            }

            string hashedRefreshToken = RefreshTokenUtils.HashRefreshToken(oldTokens.RefreshToken);
            RefreshToken token = await _repository.GetAsync(hashedRefreshToken);

            FoodRushIdentityUser user = token.IdentityUser;

            using TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);

            RefreshTokenWithRawDto newRefreshToken = await GenerateAndRotateRefreshTokenForUser(user);

            string newAccessToken = await GenerateAccessTokenForUser(user);

            scope.Complete();

            return Result<TokensDto>.Ok(new TokensDto { AcessToken = newAccessToken, RefreshToken = newRefreshToken.Token });
        }       

        private async Task<bool> IsRefreshTokenValid(string token)
        {
            string hashedToken = RefreshTokenUtils.HashRefreshToken(token);

            RefreshToken? tokenFromDb = await _repository.GetAsync(hashedToken);
            if (tokenFromDb != null)
            {
                bool hasExpired = DateTime.UtcNow > tokenFromDb.Expires;
                bool isRevoked = tokenFromDb.Revoked != null;

                if (!(hasExpired || isRevoked))
                {
                    return true;
                }
            }
            return false;
        }

        private RefreshTokenWithRawDto GenerateRefreshTokenForUser(FoodRushIdentityUser user)
        {
            string token = RefreshTokenUtils.GenerateRandomToken();
            string hashedToken = RefreshTokenUtils.HashRefreshToken(token);

            RefreshToken newRefreshToken = new RefreshToken
            {
                Id = Guid.NewGuid(),
                Token = hashedToken,
                Expires = DateTime.UtcNow.AddDays(15),
                IdentityUser = user,
                IdentityUserId = user.Id,
                Created = DateTime.UtcNow,
            };

            RefreshTokenWithRawDto responseToken = new()
            {
                Token = token,
                HashedToken = hashedToken,
                RefreshToken = newRefreshToken
            };

            return responseToken;
        }
    }
}
