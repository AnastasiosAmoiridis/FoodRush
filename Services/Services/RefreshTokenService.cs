using Data.Interfaces;
using Microsoft.Extensions.Options;
using Models.Entities.Auth;
using Models.Options.Auth;
using Results;
using Results.Enums;
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

        public async Task<Result<RefreshTokenWithRawDto>> RotateRefreshToken(string rawActiveToken, string? reason = null)
        {
            string hashedRefreshToken = RefreshTokenUtils.HashRefreshToken(rawActiveToken);

            RefreshToken? activeToken = await _repository.GetAsync(hashedRefreshToken);

            if (activeToken == null)
            {
                return Result<RefreshTokenWithRawDto>.Fail("Invalid refresh token", ResultFailureType.Authorization);
            }

            FoodRushIdentityUser? user = activeToken.IdentityUser;

            if (user == null)
            {
                return Result<RefreshTokenWithRawDto>.Fail("Invalid refresh token", ResultFailureType.Authorization);
            }

            RefreshTokenWithRawDto newToken = GenerateRefreshTokenForUser(user);

            RefreshTokenUtils.MarkRefreshTokenAsReplaced(activeToken, newToken.RefreshToken, reason);

            await _repository.AddRefreshTokenAsync(newToken.RefreshToken);

            await _repository.SaveChangesAsync();

            return Result<RefreshTokenWithRawDto>.Ok(newToken);
        }

        public async Task<RefreshTokenWithRawDto> CreateRefreshTokenForUserAsync(FoodRushIdentityUser user)
        {
            RefreshTokenWithRawDto newRefreshToken = GenerateRefreshTokenForUser(user);

            await _repository.AddRefreshTokenAsync(newRefreshToken.RefreshToken);

            await _repository.SaveChangesAsync();

            return newRefreshToken;
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
