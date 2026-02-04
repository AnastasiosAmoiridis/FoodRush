using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Services.DTOs;
using Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Services.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;

        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;

        }

        private string GenerateAccessToken(AuthUserDto authUser)
        {
            string secretKey = _configuration.GetValue<string>("Auth:JWT:SigningKey");

            SymmetricSecurityKey signKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            SigningCredentials credentials = new SigningCredentials(signKey, SecurityAlgorithms.HmacSha256);


            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, authUser.Email),
                new Claim(ClaimTypes.Role, authUser.Role),
                new Claim(ClaimTypes.Name, authUser.UserName)
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

        private string GenerateRefreshToken(int byteCount = 64)
        {
            byte[] bytes = RandomNumberGenerator.GetBytes(byteCount);

            string token = Convert.ToBase64String(bytes);
            return token;
        }

        private string HashRefreshToken(string token)
        {
            using HashAlgorithm hashAlgorithm = SHA256.Create();

            byte[] hashBytes = hashAlgorithm.ComputeHash(Convert.FromBase64String(token));

            string hash = Convert.ToBase64String(hashBytes);
            return hash;
        }
    }
}
