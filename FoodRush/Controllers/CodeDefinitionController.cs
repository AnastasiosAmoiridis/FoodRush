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

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Result<CodeDefinitionDto>>> GetByDescriptionAsync([FromQuery] string description)
        {
            Result<CodeDefinitionDto>? response = await _service.GetByDescriptionAsync(description);

            if (response.Item == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }


        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Result<CodeDefinitionDto>>> GetByIdAsync([FromQuery] Guid id)
        {
            Result<CodeDefinitionDto>? response = await _service.GetByIdAsync(id);

            if (response.Item == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }
    }
}
