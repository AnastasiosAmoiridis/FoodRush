namespace Models.Entities
{
    public class Brand
    {
        public Guid Id { get; set; }

        public required string Name { get; set; }

        public required string LogoUrl { get; set; }

        public string? Slug { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public Guid PrimaryProductCategoryId { get; set; }

        public GlobalProductCategory PrimaryProductCategory { get; set; } = null!;

        public ICollection<Store> Stores { get; set; } = new List<Store>();

        public ICollection<BrandProductCategory> BrandProductCategories { get; set; } = new List<BrandProductCategory>();
    }
}
