using Models.Entities;

namespace Services.DTOs
{
    public class CodeDefinitionDto
    {
        public Guid Id { get; set; }

        public required string Description { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public ICollection<Code>? Codes { get; set; }
    }
}
