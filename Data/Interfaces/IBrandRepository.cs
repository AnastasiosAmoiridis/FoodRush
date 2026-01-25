using Models.Entities;

namespace Data.Interfaces
{
    public interface IBrandRepository
    {
        public Task<Brand> GetByNameAsync(string name);
    }
}
