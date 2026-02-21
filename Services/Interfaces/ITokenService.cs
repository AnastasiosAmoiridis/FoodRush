using Models.Entities.Auth;
using Services.DTOs;

namespace Services.Interfaces
{
    public interface ITokenService
    {
        public Task<string> GenerateAccessTokenForUser(FoodRushIdentityUser user);

        public Task RotateRefreshTokenForUser(string userId, RefreshToken newToken, string? reason = null);

        public Task<RefreshTokenWithRawDto> GenerateAndRotateRefreshTokenForUser(FoodRushIdentityUser user);
    }
}
