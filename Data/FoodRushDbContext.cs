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

        public DbSet<StoreAddress> StoreAddresses { get; set; }

        public DbSet<Store> Stores { get; set; }

        public DbSet<Brand> Brands { get; set; }

        public DbSet<CustomerAddress> CustomerAddresses { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<GlobalProductCategory> GlobalProductCategories { get; set; }

        public DbSet<BrandProductCategory> BrandProductCategories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<OrderHeader> OrderHeaders { get; set; }

        public DbSet<OrderLine> OrderLines { get; set; }

        public DbSet<CodeDefinition> CodeDefinitions { get; set; }

        public DbSet<Code> Codes { get; set; }

        public DbSet<GlobalFilter> GlobalFilters { get; set; }

        // Junction tables
        public DbSet<OrderLineProduct> OrderLineProducts { get; set; }

        public DbSet<GlobalFilterProductOverride> GlobalFilterProductOverrides { get; set; }

        public DbSet<GlobalFilterBrandCategoryOverride> GlobalFilterBrandCategoryOverrides { get; set; }

        public DbSet<GlobalFilterGlobalCategory> GlobalFilterGlobalCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FoodRushDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
