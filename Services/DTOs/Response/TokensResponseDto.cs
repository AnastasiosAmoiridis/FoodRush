namespace Services.DTOs.Response
{
    public class TokensResponseDto
    {
        public AccessTokenWithRawDto AccessToken { get; set; }

        public RefreshTokenWithRawDto RefreshToken { get; set; }
    }
}
