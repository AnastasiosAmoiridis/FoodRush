using Microsoft.AspNetCore.Mvc;
using Services.DTOs;
using Services.Interfaces;
using Results;
using Microsoft.AspNetCore.Authorization;

namespace FoodRush.Controllers
{

    [Route("api/[controller]")]
    public class BrandController : FoodRushControllerBase
    {
        IBrandService _service;

        public BrandController(IBrandService service)
        {
            _service = service;
        }

        [HttpGet("{name}")]
        [Authorize]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Result<BrandDto>>> GetByNameAsync([FromRoute] string name)
        {
            Result<BrandDto>? response = await _service.GetByNameAsync(name);

            return HandleResult(response);
        }

        [HttpGet("{id:guid}")]
        [Authorize]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Result<BrandDto>>> GetByIdAsync([FromRoute] Guid id)
        {
            Result<BrandDto>? response = await _service.GetByIdAsync(id);

            return HandleResult(response);
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ListResult<BrandDto>>> GetAllAsync()
        {
            ListResult<BrandDto> response = await _service.GetAllAsync();

            return HandleResult(response);
        }

        [HttpPut("activate/{id}")]
        [Authorize]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Result<BrandDto>>> ActivateAsync([FromRoute] Guid id)
        {
            Result<BrandDto> response = await _service.ActivateAsync(id);

            return HandleResult(response);
        }
    }
}
