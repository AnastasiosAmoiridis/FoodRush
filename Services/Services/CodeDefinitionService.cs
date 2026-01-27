using AutoMapper;
using Data.Interfaces;
using Models.Entities;
using Results;
using Services.DTOs;
using Services.Interfaces;

namespace Services.Services
{
    public class CodeDefinitionService : ICodeDefinitionService
    {
        private readonly ICodeDefinitionRepository _repository;

        private readonly IMapper _mapper;

        public CodeDefinitionService(ICodeDefinitionRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Result<CodeDefinitionDto>> GetByDescriptionAsync(string description)
        {
            Result<CodeDefinitionDto> response = new Result<CodeDefinitionDto>();

            CodeDefinition? codeDefinition = await _repository.GetByDescriptionAsync(description);

            if (codeDefinition == null)
            {
                response.Fail($"Could not find CodeDefinition with description: '{description}'");
            }
            else
            {
                response.SetSuccess(_mapper.Map<CodeDefinitionDto>(codeDefinition));
            }

            return response;
        }
    }
}
