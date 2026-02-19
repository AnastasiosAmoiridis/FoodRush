using Microsoft.AspNetCore.Authorization;
using Results.Enums;
using Microsoft.AspNetCore.Mvc;
using Results;
using Services.DTOs;
using Services.DTOs.Response;
using Services.Interfaces;

namespace FoodRush.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service;

        public AuthController(IAuthService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        //[RequireHttps]
        [HttpPost("register")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Result<RegisterResponseDto>>> RegisterAsync([FromBody] RegisterDto registerDto)
        {
            Result<RegisterResponseDto> response = await _service.RegisterAsync(registerDto);

            if (response.Success)
            {
                return Ok(response);
            }

            return response.FailureType switch
            {
                ResultFailureType.BusinessRuleViolation => BadRequest(response),
                ResultFailureType.Validation => BadRequest(response),
            };
        }      
    }
}
