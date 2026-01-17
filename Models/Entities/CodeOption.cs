namespace Models.Entities
{
    public class CodeOption
    {
        public Guid Id { get; set; }

        public required string Name { get; set; }

        public bool IsActive { get; set; } = true;

        public Guid CodeId { get; set; }

        public Code Code { get; set; } = null!;
    }
}
