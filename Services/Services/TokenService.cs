using Data.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Models.Entities.Auth;
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

            byte[] hashBytes = hashAlgorithm.ComputeHash(Convert.FromBase64String(token));

            string hash = Convert.ToBase64String(hashBytes);
            return hash;
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

        public async Task<RefreshTokenWithRawDto> GenerateAndRotateRefreshTokenForUser(FoodRushIdentityUser user)
        {
            RefreshTokenWithRawDto newToken = GenerateRefreshTokenForUser(user);

            using TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);

            await _repository.AddTokenAsync(newToken.RefreshToken);

            await RotateRefreshTokenForUser(user.Id, newToken.RefreshToken);

            await _repository.SaveChangesAsync();

            scope.Complete();
            return newToken;
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
