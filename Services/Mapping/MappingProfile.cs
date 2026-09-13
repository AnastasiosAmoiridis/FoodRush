using AutoMapper;
using Models.Entities;
using Results;
using Services.DTOs;
using Services.DTOs.Response;

namespace Services.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Brand, BrandDto>();

            CreateMap<CustomerAddress, CustomerAddressResponseDto>().ReverseMap();

            CreateMap<CustomerAddressDto, CustomerAddress>();
        }
    }
}
