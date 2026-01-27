using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using Models.Entities;

namespace Data.Repositories
{
    public class CodeDefinitionRepository : ICodeDefinitionRepository
    {
        private readonly FoodRushDbContext _context;
        private readonly IQueryable<CodeDefinition> _query;

        public CodeDefinitionRepository(FoodRushDbContext context)
        {
            _context = context;
            _query = _context.CodeDefinitions;
        }

        public async Task<CodeDefinition>? GetByDescriptionAsync(string description)
        {
            CodeDefinition? codeDefinition = await _query
                .Where(cd => cd.IsActive)
                .FirstOrDefaultAsync(cd => cd.Description == description);

            return codeDefinition;
        }
    }
}
