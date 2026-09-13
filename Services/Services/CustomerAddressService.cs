using AutoMapper;
using Data.Interfaces;
using Models.Entities;
using Results;
using Services.DTOs;
using Services.DTOs.Response;
using Services.Interfaces;

namespace Services.Services
{
    public class CustomerAddressService : ICustomerAddressService
    {
        private readonly ICustomerAddressRepository _repository;

        private readonly ICustomerRepository _customerRepository;

        private readonly IMapper _mapper;

        public CustomerAddressService(ICustomerAddressRepository repository, ICustomerRepository customerRepository, IMapper mapper)
        {
            _repository = repository;
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<Result<CustomerAddressResponseDto>> AddAsync(CustomerAddressDto customerAddress, string userEmail)
        {
            Customer? customer = await _customerRepository.GetByEmailAsync(userEmail);
            if (customer == null)
            {
                return Result<CustomerAddressResponseDto>.Fail("", Results.Enums.ResultFailureType.Authorization);
            }
            CustomerAddress address = _mapper.Map<CustomerAddress>(customerAddress);

            address.Customer = customer;
            address.CustomerId = customer.Id;
            address.IsDeleted = false;

            await _repository.AddAsync(address);

            return Result<CustomerAddressResponseDto>.Ok(_mapper.Map<CustomerAddressResponseDto>(address));
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
