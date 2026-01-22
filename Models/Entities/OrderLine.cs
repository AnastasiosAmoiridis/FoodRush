using Models.Junctions;

namespace Models.Entities
{
    public class OrderLine
    {
        public Guid Id { get; set; }

        public string? Notes { get; set; }

        public Guid OrderHeaderId { get; set; }

        public OrderHeader OrderHeader { get; set; } = null!;

        public ICollection<OrderLineProduct> OrderLineProducts { get; set; } = new List<OrderLineProduct>();
    }
}
