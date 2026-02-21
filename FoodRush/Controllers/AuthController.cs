using Microsoft.AspNetCore.Authorization;
using Results.Enums;
using Microsoft.AspNetCore.Mvc;
using Results;
using Services.DTOs;
using Services.DTOs.Response;
using Services.Interfaces;

namespace FoodRush.Controllers
{

    [Route("api/[controller]")]
    public class AuthController : FoodRushBaseControllerBase
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

            return HandleResut(response);
        }

        [AllowAnonymous]
        //[RequireHttps]
        [HttpPost("login")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Result<LoginResponseDto>>> LoginAsync([FromBody] LoginDto loginDto)
        {
            Result<LoginResponseDto> response = await _service.LoginAsync(loginDto);

            return HandleResut(response);
        }
    }
}
