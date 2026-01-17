using Models.Entities;

namespace Models.Junctions
{
    public class GlobalFilterGlobalCategory
    {
        public Guid GlobalFilterId { get; set; }

        public GlobalFilter GlobalFilter { get; set; } = null!;

        public Guid GlobalProductCategoryId { get; set; }

        public GlobalProductCategory GlobalProductCategory { get; set; } = null!;
    }
}
