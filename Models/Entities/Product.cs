using Models.Junctions;

namespace Models.Entities
{
    public class Product
    {
        public Guid Id { get; set; }

        public required string Name { get; set; }

        public required decimal BasePrice { get; set; }

        public required string ImageUrl { get; set; }

        public string? Description { get; set; }

        public bool IsAvailable { get; set; } = true;

        public bool IsDeleted { get; set; } = false;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public Guid BrandProductCategoryId { get; set; }

        public BrandProductCategory BrandProductCategory { get; set; } = null!;

        public ICollection<OrderLineProduct> OrderLineProducts { get; set; } = new List<OrderLineProduct>();

        public ICollection<GlobalFilterProductOverride> GlobalFilterProductOverrides { get; set; } = new List<GlobalFilterProductOverride>();
    }
}
