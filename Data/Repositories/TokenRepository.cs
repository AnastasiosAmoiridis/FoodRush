using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
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

        public async Task<RefreshToken?> GetAsync(string token)
        {
            RefreshToken? refreshToken = await _context.RefreshTokens.FirstOrDefaultAsync(t => t.Token == token);
            return refreshToken;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
