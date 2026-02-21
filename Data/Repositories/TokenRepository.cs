using Data.Interfaces;
using Models.Entities.Auth;

namespace Data.Repositories
{
    public class TokenRepository : ITokenRepository
    {
        private readonly AuthDbContext _context;
        private readonly IQueryable _query;

        public TokenRepository(AuthDbContext context)
        {
            _context = context;
            _query = _context.RefreshTokens;
        }

        public async Task AddTokenAsync(RefreshToken token)
        {
            await _context.RefreshTokens.AddAsync(token);
            await _context.SaveChangesAsync();  
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
