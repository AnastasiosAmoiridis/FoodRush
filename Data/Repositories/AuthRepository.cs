using Data.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Models.Entities.Auth;

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

        public async Task<FoodRushIdentityUser?> FindByEmailOrUserNameAsync(string email = "", string userName = "")
        {
            FoodRushIdentityUser? user = await _usersQuery.OfType<FoodRushIdentityUser>()
                                                          .FirstOrDefaultAsync(ui => ui.Email == email || ui.UserName == userName);
            return user;
        }

        public async Task<FoodRushIdentityUser?> GetByEmailAsync(string email)
        {
            FoodRushIdentityUser? user = await _usersQuery.OfType<FoodRushIdentityUser>()
                                                          .FirstOrDefaultAsync(ui => ui.Email == email);
            return user;
        }

        public async Task<FoodRushIdentityUser?> GetByIdAsync(string id)
        {
            FoodRushIdentityUser? user = await _usersQuery.OfType<FoodRushIdentityUser>()
                                                       .FirstOrDefaultAsync(ui => ui.Id == id);
            return user;
        }
    }
}
