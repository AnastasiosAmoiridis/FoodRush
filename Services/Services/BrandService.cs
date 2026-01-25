using AutoMapper;
using Data.Interfaces;
using Models.Entities;
using Results;
using Results.Enums;
using Services.DTOs;
using Services.Interfaces;

namespace Services.Services
{
    public class BrandService : IBrandService
    {
        IBrandRepository _repository;
        IMapper _mapper;

        public BrandService(IBrandRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Result<BrandDto>> GetByNameAsync(string name)
        {
            Result<BrandDto> response = new Result<BrandDto>();
            try
            {
                Brand? brand = await _repository.GetByNameAsync(name);

                if (brand == null)
                {
                    response.FailWithCode(HttpResultCode.NotFound, $"Could not find Brand '{name}'");
                    return response;
                }

                response.SetSuccess(_mapper.Map<BrandDto>(brand));
                return response;

            }
            catch
            {
                response.FailWithCode(HttpResultCode.InternalServerError, $"An error occured while fetching Brand '{name}'");
                return response;
            }
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

