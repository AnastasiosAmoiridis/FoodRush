using Models.Entities;

namespace Models.Junctions
{
    public class GlobalFilterBrandCategoryOverride
    {
        public required string NewFilterConfig { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public Guid GlobalFilterId { get; set; }

        public GlobalFilter GlobalFilter { get; set; } = null!;

        public Guid BrandProductCategoryId { get; set; }

        public BrandProductCategory BrandProductCategory { get; set; } = null!;
    }
}
