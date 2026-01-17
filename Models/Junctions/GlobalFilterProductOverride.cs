using Models.Entities;

namespace Models.Junctions
{
    public class GlobalFilterProductOverride
    {
        public required string NewFilterConfig { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public Guid ProductId { get; set; }

        public Product Product { get; set; } = null!;

        public Guid GlobalFilterId { get; set; }

        public GlobalFilter GlobalFilter { get; set; } = null!;
    }
}
