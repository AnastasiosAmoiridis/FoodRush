using Results;
using Services.DTOs;

namespace Services.Interfaces
{
    public interface ICodeDefinitionService
    {
        public Task<Result<CodeDefinitionDto>> GetByDescriptionAsync(string description);

        public Task<Result<CodeDefinitionDto>> GetByIdAsync(Guid id);
    }
}
