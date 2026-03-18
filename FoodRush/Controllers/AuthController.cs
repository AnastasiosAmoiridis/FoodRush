using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Results;
using Results.Enums;
using Services.DTOs;
using Services.DTOs.Response;
using Services.Interfaces;

namespace FoodRush.Controllers
{

    [Route("api/[controller]")]
    public class AuthController : FoodRushControllerBase
    {
        private readonly IAuthService _service;

        private readonly ITokenService _tokenService;

        public AuthController(IAuthService service, ITokenService tokenService)
        {
            _service = service;
            _tokenService = tokenService;
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

            return HandleResult(response);
        }

        [AllowAnonymous]
        //[RequireHttps]
        [HttpPost("login")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Result<RefreshTokenResponseDto>>> LoginAsync([FromBody] LoginDto loginDto)
        {
            Result<RefreshTokenResponseDto> response;

            Result<TokensResponseDto> loginResponse = await _service.LoginAsync(loginDto);
            if (loginResponse.Success)
            {
                DateTime accessTokenExpirationDate = loginResponse.Item.AccessToken.AccessToken.ValidTo;

                HttpContext.Response.Cookies.Append("AccessToken", loginResponse.Item!.AccessToken.Token, new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.Strict,
                    Expires = accessTokenExpirationDate
                });

                response = Result<RefreshTokenResponseDto>.Ok(new RefreshTokenResponseDto()
                {
                    RefreshToken = loginResponse.Item.RefreshToken.Token
                });
            }
            else
            {
                ResultFailureType failureType = (ResultFailureType)Enum.Parse(typeof(ResultFailureType), loginResponse.FailureType);
                response = Result<RefreshTokenResponseDto>.Fail(loginResponse.ErrorDetails, failureType);
            }

            return HandleResult(response);
        }

        [AllowAnonymous]
        //[RequireHttps]
        [HttpPost("refreshAccessToken")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Result<TokensDto>>> RefreshAccessTokenAsync([FromBody] TokensDto oldTokens)
        {
            Result<TokensDto> response = await _tokenService.RefreshAccessTokenAsync(oldTokens);

            return HandleResult(response);
        }
    }
}
