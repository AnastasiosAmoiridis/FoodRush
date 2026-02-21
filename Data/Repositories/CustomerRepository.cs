using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly FoodRushDbContext _context;

        private IQueryable<Customer> _query;

        public CustomerRepository(FoodRushDbContext context)
        {
            _context = context;
            _query = _context.Customers;
        }

        public async Task<Customer> AddAsync(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task DeleteAsync(Customer customer)
        {
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
        }

        public async Task<Customer?> GetByEmailAsync(string email)
        {
            Customer? customer = await _query.FirstOrDefaultAsync(c => c.Email == email);
            return customer;
        }
    }
}
