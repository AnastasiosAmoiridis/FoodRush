using Models.Entities.Auth;

namespace Data.Interfaces
{
    public interface IAuthRepository
    {
        public Task<FoodRushIdentityUser?> GetByEmailAsync(string email);

        public Task<FoodRushIdentityUser?> GetByIdAsync(string id);

        public Task<FoodRushIdentityUser?> FindByEmailOrUserNameAsync(string email = "", string userName = "");
    }
}
