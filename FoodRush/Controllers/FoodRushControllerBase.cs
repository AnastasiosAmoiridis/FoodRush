using Microsoft.AspNetCore.Mvc;
using Results;
using Results.Enums;

namespace FoodRush.Controllers
{

    [ApiController]
    public abstract class FoodRushControllerBase : ControllerBase
    {
        protected ActionResult<T> HandleResult<T>(T result) where T : ResultBase
        {
            if (result.Success)
            {
                return Ok(result);
            }

            if (!Enum.TryParse<ResultFailureType>(result.FailureType, out var failureEnum))
            {
                // Unknown failure type, fallback to 500
                return StatusCode(StatusCodes.Status500InternalServerError, result);
            }

            return failureEnum switch
            {
                ResultFailureType.Validation => BadRequest(result),
                ResultFailureType.BusinessRuleViolation => BadRequest(result),
                ResultFailureType.NotFound => NotFound(result),
                ResultFailureType.Authentication => Unauthorized(result),
                ResultFailureType.Authorization => Forbid(),
                ResultFailureType.TransactionFailure => StatusCode(StatusCodes.Status500InternalServerError, result),
                _ => StatusCode(StatusCodes.Status500InternalServerError, result)
            };
        }
    }
}
