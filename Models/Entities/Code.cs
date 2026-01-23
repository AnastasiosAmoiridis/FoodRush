namespace Models.Entities
{


    public class Code
    {
        public Guid Id { get; set; }

        public required string Description { get; set; }

        public bool IsActive { get; set; } = true;

        public Guid CodeDefinitionId { get; set; }

        public CodeDefinition CodeDefinition { get; set; } = null!;

        public ICollection<OrderHeader> PaymentOrderHeaders { get; set; } = new List<OrderHeader>();

        public ICollection<OrderHeader> OrderStatusOrderHeaders { get; set; } = new List<OrderHeader>();
    }
}
