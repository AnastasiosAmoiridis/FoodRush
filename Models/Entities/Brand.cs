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
    }
}
