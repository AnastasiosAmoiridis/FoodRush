namespace Models.Entities
{
    public class OrderHeader
    {
        public Guid Id { get; set; }

        public required decimal TotalCost { get; set; }

        public string? Notes { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public Guid CustomerId { get; set; }

        public Customer Customer { get; set; } = null!;

        public Guid PaymentCodeId { get; set; }

        public Code PaymentCode { get; set; } = null!;

        public Guid OrderStatusCodeId { get; set; }

        public Code OrderStatus { get; set; } = null!;

        public ICollection<OrderLine> OrderLines { get; set; } = new List<OrderLine>();
    }
}
