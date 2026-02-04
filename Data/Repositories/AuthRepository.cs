using Data.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly AuthDbContext _contex;
        private readonly IQueryable<IdentityUser> _usersQuery;

        public AuthRepository(AuthDbContext contex)
        {
            _contex = contex;
            _usersQuery = _contex.Users;
        }
    }
}
