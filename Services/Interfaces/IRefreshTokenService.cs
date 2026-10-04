using Models.Entities.Auth;
using Results;
using Services.DTOs;

namespace Services.Interfaces
{
    public interface IRefreshTokenService
    {
        public Task<Result<RefreshTokenWithRawDto>> RotateRefreshToken(string rawActiveToken, string? reason = null);       

        public Task<RefreshTokenWithRawDto> CreateRefreshTokenForUserAsync(FoodRushIdentityUser user); 
    }
}
