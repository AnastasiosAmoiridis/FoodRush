namespace Models.Entities
{


    public class Code
    {
        public Guid Id { get; set; }

        public required string Name { get; set; }

        public string? Description { get; set; }

        public bool IsActive { get; set; } = true;

        //public ICollection<CodeDefinition> CodeDefinitions { get; set; } = new List<CodeDefinition>();
    }
}
