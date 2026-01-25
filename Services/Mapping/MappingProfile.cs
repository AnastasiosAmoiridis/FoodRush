using AutoMapper;
using Models.Entities;
using Services.DTOs;

namespace Services.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Brand, BrandDto>();
        }
    }
}
