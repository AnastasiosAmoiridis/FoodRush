using Models.Entities.Auth;
using Results;
using Services.DTOs;

namespace Services.Interfaces
{
    public interface IRefreshTokenService
    {
        public Task<RefreshTokenWithRawDto> RotateRefreshToken(string rawActiveToken, string? reson = null);

    }
}
