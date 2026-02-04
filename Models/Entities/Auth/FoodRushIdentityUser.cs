using Microsoft.AspNetCore.Identity;

namespace Models.Entities.Auth
{
    public class FoodRushIdentityUser : IdentityUser
    {
        public ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();
    }
}
