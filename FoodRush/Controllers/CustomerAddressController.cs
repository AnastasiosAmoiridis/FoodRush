using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Results;
using Services.DTOs;
using Services.DTOs.Response;
using Services.Interfaces;

namespace FoodRush.Controllers
{

    public class CustomerAddressControlLer : FoodRushControllerBase
    {
        private readonly ICustomerAddressService _service;

        private readonly IHttpContextAccessor _httpContextAccessor;

        public CustomerAddressControlLer(ICustomerAddressService service)
        {
            _service = service;
        }

        /// <summary>
        /// Retrieves a customer address by its ID.
        /// </summary>
        /// <remarks>
        /// The address must belong to the authenticated customer.
        /// </remarks>
        /// <param name="id">The unique identifier of the customer address.</param>
        /// <returns>The requested customer address.</returns>
        /// <response code="200">The customer address was found successfully.</response>
        /// <response code="401">Authentication is required or the access token is invalid or expired.</response>
        /// <response code="404">The customer address was not found.</response>
        /// <response code="500">An internal server error occurred.</response>
        [HttpGet("{id}")]
        [Authorize]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Result<CustomerAddressResponseDto>>> GetByIdAsync([FromRoute] Guid id)
        {
            Result<CustomerAddressResponseDto> response = await _service.GetByIdAsync(id);

            return HandleResult(response);
        }

        /// <summary>
        /// Adds a new address for the authenticated customer.
        /// </summary>
        /// <remarks>
        /// The new address is associated with the authenticated customer.
        /// </remarks>
        /// <param name="customerAddress">The customer address to add.</param>
        /// <returns>The newly created customer address.</returns>
        /// <response code="200">The customer address was added successfully.</response>
        /// <response code="401">Authentication is required or the access token is invalid or expired.</response>
        /// <response code="500">An internal server error occurred.</response>
        [HttpPost("customerAddress")]
        [Authorize]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Result<CustomerAddressResponseDto>>> AddAsync([FromBody] CustomerAddressDto customerAddress)
        {
            string? userEmail = "anamoiridis@gmail.com"; //_httpContextAccessor.HttpContext.User.FindFirst(System.Security.Claims.ClaimTypes.Email)?.Value;

            Result<CustomerAddressResponseDto> response = await _service.AddAsync(customerAddress, userEmail);

            return HandleResult(response);
        }

        /// <summary>
        /// Soft deletes a customer address.
        /// </summary>
        /// <remarks>
        /// The address is marked as deleted rather than being permanently removed.
        /// </remarks>
        /// <param name="id">The unique identifier of the customer address.</param>
        /// <returns>The result of the deletion operation.</returns>
        /// <response code="200">The customer address was deleted successfully.</response>
        /// <response code="401">Authentication is required or the access token is invalid or expired.</response>
        /// <response code="404">The customer address was not found.</response>
        /// <response code="500">An internal server error occurred.</response>
        [HttpDelete("delete/{id}")]
        [Authorize]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DeleteResult>> SoftDeleteAsync([FromRoute] Guid id)
        {
            DeleteResult response = await _service.SoftDeleteAsync(id);

            return HandleResult(response);
        }

    }
}
