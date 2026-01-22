using Microsoft.EntityFrameworkCore;
using Models.Entities;
using Models.Junctions;

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

        DbSet<GlobalProductCategory> GlobalProductCategories { get; set; }

        DbSet<BrandProductCategory> BrandProductCategories { get; set; }

        DbSet<Product> Products { get; set; }

        DbSet<OrderHeader> OrderHeaders { get; set; }

        DbSet<OrderLine> OrderLines { get; set; }

        DbSet<CodeDefinition> CodeDefinitions { get; set; }

        DbSet<Code> Codes { get; set; }

        DbSet<GlobalFilter> GlobalFilters { get; set; }

        // Junction tables
        DbSet<OrderLineProduct> OrderLineProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FoodRushDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
