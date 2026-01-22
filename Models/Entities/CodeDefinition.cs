namespace Models.Entities
{
    public class CodeDefinition
    {
        public Guid Id { get; set; }

        public required string Description { get; set; }

        public bool IsActive { get; set; } = true;

        public bool IsDeleted { get; set; } = false;

        public ICollection<Code> Codes { get; set; } = new List<Code>();
    }
}
