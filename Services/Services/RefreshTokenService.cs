using Data.Interfaces;
using Microsoft.Extensions.Options;
using Models.Entities.Auth;
using Models.Options.Auth;
using Services.DTOs;
using Services.Interfaces;

namespace Services.Services
{
    internal class RefreshTokenService : IRefreshTokenService
    {
        private readonly IRefreshTokenRepository _repository;

        private readonly AuthOptions _authOptions;

        public RefreshTokenService(IRefreshTokenRepository repository, IOptions<AuthOptions> options)
        {
            _repository = repository;
            _authOptions = options.Value;
        }

        public async Task<RefreshTokenWithRawDto> RotateRefreshToken(string rawActiveToken, string? reson = null)
        {
            string hashedRefreshToken = RefreshTokenUtils.HashRefreshToken(rawActiveToken);

            RefreshToken? activeToken = await _repository.GetAsync(hashedRefreshToken) ??
                                              throw new NullReferenceException("Could not find the provided 'active' token");

            FoodRushIdentityUser? user = activeToken.IdentityUser ??
                                         throw new NullReferenceException("Could not find an associated user for the provided 'active' token");

            RefreshTokenWithRawDto newToken = GenerateRefreshTokenForUser(user);

            RefreshTokenUtils.MarkRefreshTokenAsReplaced(activeToken, newToken.RefreshToken, reson);
            await _repository.AddRefreshTokenAsync(newToken.RefreshToken);

            await _repository.SaveChangesAsync();

            return newToken;
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
