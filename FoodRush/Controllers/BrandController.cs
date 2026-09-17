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

        /// <summary>
        /// Retrieves a brand by its name.
        /// </summary>
        /// <remarks>
        /// The brand must belong to the authenticated user.
        /// </remarks>
        /// <param name="name">The name of the brand.</param>
        /// <returns>The requested brand.</returns>
        /// <response code="200">The brand was found successfully.</response>
        /// <response code="401">Authentication is required or the access token is invalid or expired.</response>
        /// <response code="404">The brand was not found.</response>
        /// <response code="500">An internal server error occurred.</response>
        [HttpGet("{name}")]
        [Authorize]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Result<BrandDto>>> GetByNameAsync([FromRoute] string name)
        {
            Result<BrandDto>? response = await _service.GetByNameAsync(name);

            return HandleResult(response);
        }

        /// <summary>
        /// Retrieves a brand by its ID.
        /// </summary>
        /// <remarks>
        /// The brand must belong to the authenticated user.
        /// </remarks>
        /// <param name="id">The unique identifier of the brand.</param>
        /// <returns>The requested brand.</returns>
        /// <response code="200">The brand was found successfully.</response>
        /// <response code="401">Authentication is required or the access token is invalid or expired.</response>
        /// <response code="404">The brand was not found.</response>
        /// <response code="500">An internal server error occurred.</response>
        [HttpGet("{id:guid}")]
        [Authorize]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Result<BrandDto>>> GetByIdAsync([FromRoute] Guid id)
        {
            Result<BrandDto>? response = await _service.GetByIdAsync(id);

            return HandleResult(response);
        }

        /// <summary>
        /// Retrieves all brands.
        /// </summary>
        /// <remarks>
        /// This endpoint does not require authentication and will return all brands in the system. 
        /// It is used for demo perposes and may not be suitable for production environments where data privacy is a concern.
        /// </remarks>
        /// <returns>A list of all brands.</returns>
        /// <response code="200">The brands were retrieved successfully.</response>
        /// <response code="500">An internal server error occurred.</response>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ListResult<BrandDto>>> GetAllAsync()
        {
            ListResult<BrandDto> response = await _service.GetAllAsync();

            return HandleResult(response);
        }

        /// <summary>
        /// Activates a brand.
        /// </summary>
        /// <remarks>
        /// The brand must belong to the authenticated user.
        /// </remarks>
        /// <param name="id">The unique identifier of the brand.</param>
        /// <returns>The activated brand.</returns>
        /// <response code="200">The brand was activated successfully.</response>
        /// <response code="401">Authentication is required or the access token is invalid or expired.</response>
        /// <response code="404">The brand was not found.</response>
        /// <response code="500">An internal server error occurred.</response>
        [HttpPut("activate/{id}")]
        [Authorize]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Result<BrandDto>>> ActivateAsync([FromRoute] Guid id)
        {
            Result<BrandDto> response = await _service.ActivateAsync(id);

            return HandleResult(response);
        }
    }
}
