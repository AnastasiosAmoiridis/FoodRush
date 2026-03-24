using AutoMapper;
using Data.Interfaces;
using Models.Entities;
using Results;
using Services.DTOs.Response;
using Services.Interfaces;

namespace Services.Services
{
    public class CustomerAddressService : ICustomerAddressService
    {
        private readonly ICustomerAddressRepository _repository;

        private readonly IMapper _mapper;

        public CustomerAddressService(ICustomerAddressRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<CustomerAddressResponseDto>> GetByIdAsync(Guid id)
        {
            CustomerAddress? customerAddress = await _repository.GetByIdAsync(id);

            return Result<CustomerAddressResponseDto>.Ok(_mapper.Map<CustomerAddressResponseDto>(customerAddress));
        }        

        public async Task<DeleteResult> SoftDeleteAsync(Guid id)
        {
            CustomerAddress? customerAddress = await _repository.GetByIdAsync(id);

            if (customerAddress == null)
            {
                return DeleteResult.Fail("Could not find CustomerAddress", Results.Enums.ResultFailureType.NotFound);
            }

            customerAddress.IsDeleted = true;

            await _repository.UpdateAsync();

            return DeleteResult.Ok();
        }
    }
}
