using Models.Entities;

namespace Data.Interfaces
{
    public interface ICustomerAddressRepository
    {
        public Task<CustomerAddress?> GetByIdAsync(Guid id);
    }
}
