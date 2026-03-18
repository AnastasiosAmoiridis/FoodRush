using System.IdentityModel.Tokens.Jwt;

namespace Services.DTOs
{
    public class AccessTokenWithRawDto
    {
        public string Token { get; set; }

        public JwtSecurityToken AccessToken { get; set; }
    }
}
