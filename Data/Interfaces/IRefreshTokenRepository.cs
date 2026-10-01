using Models.Entities.Auth;

namespace Data.Interfaces
{
    public interface IRefreshTokenRepository
    {
        public Task SaveChangesAsync();

        public Task AddRefreshTokenAsync(RefreshToken token);

        public Task<RefreshToken?> GetAsync(string token);
    }
}
