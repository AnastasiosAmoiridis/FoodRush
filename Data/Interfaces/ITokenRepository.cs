using Models.Entities.Auth;

namespace Data.Interfaces
{
    public interface ITokenRepository
    {
        public Task SaveChangesAsync();

        public Task AddTokenAsync(RefreshToken token);
    }
}
