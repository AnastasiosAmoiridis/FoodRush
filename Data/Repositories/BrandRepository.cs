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

        public async Task<Brand> GetByNameAsync(string name)
        {
            Brand? brand = await _query.SingleOrDefaultAsync(b => b.Name == name);

            return brand;
        }
    }
}
