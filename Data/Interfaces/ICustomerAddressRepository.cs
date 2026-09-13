using Models.Entities;

namespace Data.Interfaces
{
    public interface ICustomerAddressRepository
    {
        public Task<CustomerAddress?> GetByIdAsync(Guid id);

        public Task AddAsync(CustomerAddress customerAddress);

        public Task UpdateAsync();
    }
}
