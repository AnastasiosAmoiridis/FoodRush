using AutoMapper;
using Data.Interfaces;
using Models.Entities;
using Results;
using Services.DTOs;
using Services.Interfaces;
using Results.Enums;

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
            Brand? brand = await _repository.GetByNameAsync(name);

            if (brand == null)
            {
                return Result<BrandDto>.Fail("Was not able to find that brand", ResultFailureType.NotFound);
            }

            return Result<BrandDto>.Ok(_mapper.Map<BrandDto>(brand));
        }

        public async Task<Result<BrandDto>> GetByIdAsync(Guid id)
        {
            Brand? brand = await _repository.GetByIdAsync(id);

            if (brand == null)
            {
                return Result<BrandDto>.Fail("Was not able to find that brand", ResultFailureType.NotFound);
            }

            return Result<BrandDto>.Ok(_mapper.Map<BrandDto>(brand));
        }

        public async Task<ListResult<BrandDto>> GetAllAsync()
        {
            List<Brand> brands = await _repository.GetAllAsync();

            return ListResult<BrandDto>.Ok(_mapper.Map<List<BrandDto>>(brands));
        }

        public async Task<Result<BrandDto>> ActivateAsync(Guid id)
        {
            Brand? brand = await _repository.GetByIdAsync(id);

            if (brand == null)
            {
                return Result<BrandDto>.Fail("Was not able to find that brand", ResultFailureType.NotFound);
            }

            await _repository.ActivateAsync(id);

            brand.IsActive = true;

            return Result<BrandDto>.Ok(_mapper.Map<BrandDto>(brand));
        }
    }
}

