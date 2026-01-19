using Microsoft.EntityFrameworkCore;

namespace Data
{
    internal class FoodRushDbContext : DbContext
    {
        public FoodRushDbContext(DbContextOptions<FoodRushDbContext> options)
            : base(options)
        {
        }
    }
}
