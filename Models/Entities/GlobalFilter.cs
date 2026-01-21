namespace Models.Entities
{
    public class GlobalFilter
    {
        public Guid Id { get; set; }

        public required string FilterConfig { get; set; }

        //public ICollection<GlobalProductCategory> GlobalProductCategories { get; set; } = new List<GlobalProductCategory>();

        //public ICollection<BrandProductCategory> BrandProductCategories { get; set; } = new List<BrandProductCategory>();

        //public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
