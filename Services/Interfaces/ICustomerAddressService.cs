using Results;
using Services.DTOs.Response;

namespace Services.Interfaces
{
    public interface ICustomerAddressService
    {
        public Task<Result<CustomerAddressResponseDto>> GetByIdAsync(Guid id);
    }
}
