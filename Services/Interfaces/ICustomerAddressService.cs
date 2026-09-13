using Results;
using Services.DTOs;
using Services.DTOs.Response;

namespace Services.Interfaces
{
    public interface ICustomerAddressService
    {
        public Task<Result<CustomerAddressResponseDto>> GetByIdAsync(Guid id);

        public Task<DeleteResult> SoftDeleteAsync(Guid id);

        public Task<Result<CustomerAddressResponseDto>> AddAsync(CustomerAddressDto customerAddress, string userEmail);
    }
}
