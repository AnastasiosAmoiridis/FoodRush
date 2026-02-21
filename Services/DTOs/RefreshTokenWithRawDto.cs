using Models.Entities.Auth;

namespace Services.DTOs
{
    public class RefreshTokenWithRawDto
    {
        public string Token { get; set; }

        public string HashedToken { get; set; }

        public RefreshToken RefreshToken { get; set; }
    }
}
