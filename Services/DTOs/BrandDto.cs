using Models.Entities;

namespace Services.DTOs
{
    public class BrandDto
    {
        public Guid Id { get; set; }

        public required string Name { get; set; }

        public required string LogoUrl { get; set; }

        public string? Slug { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; }

        public Guid PrimaryProductCategoryId { get; set; }

        public GlobalProductCategory PrimaryProductCategory { get; set; }

        public ICollection<Store> Stores { get; set; } = new List<Store>();

        public ICollection<BrandProductCategory> BrandProductCategories { get; set; }
    }
}
