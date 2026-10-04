using Models.Entities.Auth;
using Results;
using Services.DTOs;
using Services.DTOs.Response;

namespace Services.Interfaces
{
    public interface IAuthService
    {
        public Task<Result<TokensResponseDto>> LoginAsync(LoginDto loginDto);

        public Task<Result<TokensDto>> RefreshAccessTokenAsync(string refreshToken);

        public Task<Result<RegisterResponseDto>> RegisterAsync(RegisterDto registerDto);    
    }
}
