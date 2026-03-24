using Microsoft.AspNetCore.Mvc;
using Results;
using Services.DTOs.Response;
using Services.Interfaces;

namespace FoodRush.Controllers
{

    public class CustomerAddressControlLer : FoodRushControllerBase
    {
        private readonly ICustomerAddressService _service;

        public CustomerAddressControlLer(ICustomerAddressService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Result<CustomerAddressResponseDto>>> GetByIdAsync([FromRoute] Guid id)
        {
            Result<CustomerAddressResponseDto> response = await _service.GetByIdAsync(id);

            return HandleResult(response);
        }

        [HttpDelete("delete/{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DeleteResult>> SoftDeleteAsync([FromRoute] Guid id)
        {
            DeleteResult response = await _service.SoftDeleteAsync(id);

            return HandleResult(response);
        }

    }
}
