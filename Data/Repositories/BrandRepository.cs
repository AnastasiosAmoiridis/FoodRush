using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace Data.Repositories
{
    public class BrandRepository : IBrandRepository
    {
        private FoodRushDbContext _context;
        private IQueryable<Brand> _query;

        public BrandRepository(FoodRushDbContext context)
        {
            _context = context;
            _query = _context.Brands;
        }

        public async Task<List<Brand>> GetAllAsync()
        {
            List<Brand> brands = await _query.ToListAsync();

            return brands;
        }

        public async Task<Brand> GetByNameAsync(string name)
        {
            Brand? brand = await _query.SingleOrDefaultAsync(b => b.Name == name);

            return brand;
        }

        public async Task<Brand> GetByIdAsync(Guid id)
        {
            Brand? brand = await _query.SingleOrDefaultAsync(b => b.Id == id);

            return brand;
        }
    }
}
