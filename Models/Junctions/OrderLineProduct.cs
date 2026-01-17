using Models.Entities;

namespace Models.Junctions
{
    public class OrderLineProduct
    {
        public int ProductCount { get; set; }

        public required string ProductFilterOptions { get; set; } // Stored as JSON combining all actual filters chosen for a Product in a ProductLine

        public decimal LinePrice { get; set; } = 0m;

        public Guid ProductId { get; set; }

        public Product Product { get; set; } = null!;

        public Guid OrderLineId { get; set; }

        public OrderLine OrderLine { get; set; } = null!;
    }
}
