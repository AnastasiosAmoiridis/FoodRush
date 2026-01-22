namespace Models.Entities
{


    public class Code
    {
        public Guid Id { get; set; }

        public required string Name { get; set; }

        public string? Description { get; set; }

        public bool IsActive { get; set; } = true;

        public ICollection<CodeDefinition> CodeDefinitions { get; set; } = new List<CodeDefinition>();

        public ICollection<OrderHeader> PaymentOrderHeaders { get; set; } = new List<OrderHeader>();

        public ICollection<OrderHeader> OrderStatusOrderHeaders { get; set; } = new List<OrderHeader>();
    }
}
