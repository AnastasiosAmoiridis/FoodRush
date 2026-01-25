using Results;
using Services.DTOs;

namespace Services.Interfaces
{
    public interface IBrandService
    {
        Task<Result<BrandDto>> GetByNameAsync(string name);
    }
}
