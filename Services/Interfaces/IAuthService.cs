using Results;
using Services.DTOs;
using Services.DTOs.Response;

namespace Services.Interfaces
{
    public interface IAuthService
    {
        public Task<Result<LoginResponseDto>> LoginAsync(LoginDto loginDto);

        public Task<Result<RegisterResponseDto>> RegisterAsync(RegisterDto registerDto);
    }
}
