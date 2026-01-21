using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace Data
{
    public class FoodRushDbContext : DbContext
    {
        public FoodRushDbContext(DbContextOptions<FoodRushDbContext> options)
            : base(options)
        {
        }

        DbSet<StoreAddress> StoreAddresses { get; set; }

        DbSet<Store> Stores { get; set; }

        DbSet<Brand> Brands { get; set; }

        DbSet<CustomerAddress> CustomerAddresses { get; set; }

        DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FoodRushDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
