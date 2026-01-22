using Models.Junctions;

namespace Models.Entities
{
    public class GlobalFilter
    {
        public Guid Id { get; set; }

        public required string FilterConfig { get; set; }

        //public ICollection<GlobalProductCategory> GlobalProductCategories { get; set; } = new List<GlobalProductCategory>();

        public ICollection<GlobalFilterBrandCategoryOverride> GlobalFilterBrandCategoryOverrides { get; set; } = new List<GlobalFilterBrandCategoryOverride>();

        public ICollection<GlobalFilterProductOverride> GlobalFilterProductOverrides { get; set; } = new List<GlobalFilterProductOverride>();
    }
}
