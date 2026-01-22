using Models.Junctions;

namespace Models.Entities
{
    public class GlobalFilter
    {
        public Guid Id { get; set; }

        public required string FilterConfig { get; set; }

        public ICollection<GlobalFilterGlobalCategory> GlobalFilterGlobalCategories { get; set; } = new List<GlobalFilterGlobalCategory>();

        public ICollection<GlobalFilterBrandCategoryOverride> GlobalFilterBrandCategoryOverrides { get; set; } = new List<GlobalFilterBrandCategoryOverride>();

        public ICollection<GlobalFilterProductOverride> GlobalFilterProductOverrides { get; set; } = new List<GlobalFilterProductOverride>();
    }
}
