using AutoMapper;
using Data.Interfaces;
using Models.Entities;
using Results;
using Services.DTOs;
using Services.Interfaces;

namespace Services.Services
{
    public class BrandService : IBrandService
    {
        readonly IBrandRepository _repository;
        readonly IMapper _mapper;

        public BrandService(IBrandRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<BrandDto>> GetByNameAsync(string name)
        {
            Result<BrandDto> response = new Result<BrandDto>();

            Brand? brand = await _repository.GetByNameAsync(name);

            response.SetSuccess(_mapper.Map<BrandDto>(brand));

            return response;
        }

        public async Task<Result<BrandDto>> GetByIdAsync(Guid id)
        {
            Result<BrandDto> response = new Result<BrandDto>();

            Brand? brand = await _repository.GetByIdAsync(id);

            response.SetSuccess(_mapper.Map<BrandDto>(brand));

            return response;
        }

        public async Task<ListResult<BrandDto>> GetAllAsync()
        {
            ListResult<BrandDto> response = new ListResult<BrandDto>();

            List<Brand> brands = await _repository.GetAllAsync();

            response.SetSucess(_mapper.Map<List<BrandDto>>(brands));

            return response;
        }
    }
}

