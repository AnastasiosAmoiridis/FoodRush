using Models.Entities;

namespace Data.Interfaces
{
    public interface IBrandRepository
    {
        public Task<Brand> GetByNameAsync(string name);

        public Task<Brand> GetByIdAsync(Guid id);

        public Task ActivateAsync(Guid id);

        public Task<List<Brand>> GetAllAsync();
    }
}
