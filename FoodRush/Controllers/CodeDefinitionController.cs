using Microsoft.AspNetCore.Mvc;
using Results;
using Services.DTOs;
using Services.Interfaces;

namespace FoodRush.Controllers
{
    [ApiController()]
    [Route("api/[controller]")]
    public class CodeDefinitionController : ControllerBase
    {
        private readonly ICodeDefinitionService _service;

        public CodeDefinitionController(ICodeDefinitionService service)
        {
            _service = service;
        }

        [HttpGet("{description}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Result<CodeDefinitionDto>>> GetByDescriptionAsync([FromRoute] string description)
        {
            Result<CodeDefinitionDto>? response = await _service.GetByDescriptionAsync(description);

            if (response.Item == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }
    }
}
