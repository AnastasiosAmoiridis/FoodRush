using Results;
using Services.DTOs;

namespace Services.Interfaces
{
    public interface IBrandService
    {
        Task<Result<BrandDto>> GetByNameAsync(string name);

        Task<Result<BrandDto>> GetByIdAsync(Guid id);

        Task<Result<BrandDto>> ActivateAsync(Guid id);

        Task<ListResult<BrandDto>> GetAllAsync();
    }
}
