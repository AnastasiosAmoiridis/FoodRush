using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class FoodRushDbContext : DbContext
    {
        public FoodRushDbContext(DbContextOptions<FoodRushDbContext> options)
            : base(options)
        {
        }
    }
}
