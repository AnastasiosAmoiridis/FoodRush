using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace Data.Repositories
{
    public class CustomerAddressRepository : ICustomerAddressRepository
    {
        private readonly FoodRushDbContext _context;

        private readonly IQueryable<CustomerAddress> _query;

        public CustomerAddressRepository(FoodRushDbContext context)
        {
            _context = context;
            _query = _context.CustomerAddresses;
        }

        public async Task<CustomerAddress?> GetByIdAsync(Guid id)
        {
            CustomerAddress? customerAddress = await _query.FirstOrDefaultAsync(ca => ca.Id == id);

            return customerAddress;
        }
    }
}
