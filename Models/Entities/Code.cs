namespace Models.Entities
{
    public enum CodeType
    {
        Payment,
        OrderStatus
    }

    public class Code
    {
        public Guid Id { get; set; }

        public required string Name { get; set; }

        public CodeType Type { get; set; }

        public string? Description { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
