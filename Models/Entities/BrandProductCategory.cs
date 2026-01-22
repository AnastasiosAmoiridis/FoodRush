namespace Models.Entities
{
    public class BrandProductCategory
    {
        public Guid Id { get; set; }

        public required string Name { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public bool IsDeleted { get; set; } = false;

        //public Guid GlobalProductCategoryId { get; set; }

        //public GlobalProductCategory GlobalProductCategory { get; set; } = null!;

        public Guid BrandId { get; set; }

        public Brand Brand { get; set; } = null!;

        //public ICollection<Product> Products { get; set; } = new List<Product>();

        //public ICollection<GlobalFilter> GlobalFilters { get; set; } = new List<GlobalFilter>();
    }
}
