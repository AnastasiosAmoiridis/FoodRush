using Microsoft.AspNetCore.Mvc;
using Services.DTOs;
using Services.Interfaces;
using Results;
using Results.Enums;

namespace FoodRush.Controllers
{
    [ApiController()]
    [Route("api/[controller]")]
    public class BrandController : ControllerBase
    {
        IBrandService _service;

        public BrandController(IBrandService service)
        {
            _service = service;
        }

        [HttpGet("{name}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Result<BrandDto>>> GetByNameAsync([FromRoute] string name)
        {

            Result<BrandDto>? response = await _service.GetByNameAsync(name);
            if (response.Success)
            {
                return Ok(response);
            }
            return StatusCode((int)response.Code, response.ErrorDetails);
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ListResult<BrandDto>>> GetAllAsync()
        {
            ListResult<BrandDto> response = await _service.GetAllAsync();
            if (response.Success)
            {
                return Ok(response);
            }

            if (response.HasValidationErrors)
            {
                return BadRequest(response.ValidationErrors);
            }
            
            return Problem(
                detail: response.ErrorDetails,
                statusCode: StatusCodes.Status500InternalServerError
            );
        }
    }
}
