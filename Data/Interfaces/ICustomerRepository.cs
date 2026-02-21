using Models.Entities;

namespace Data.Interfaces

{
    public interface ICustomerRepository
    {
        public Task<Customer> AddAsync(Customer customer);

        public Task DeleteAsync(Customer customer);

        public Task<Customer?> GetByEmailAsync(string email);
    }
}
