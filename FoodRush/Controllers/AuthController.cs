using Microsoft.AspNetCore.Mvc;
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
    }
}
