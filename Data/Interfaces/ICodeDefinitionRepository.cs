using Models.Entities;

namespace Data.Interfaces
{
    public interface ICodeDefinitionRepository
    {
        public Task<CodeDefinition>? GetByDescriptionAsync(string description);
    }
}
