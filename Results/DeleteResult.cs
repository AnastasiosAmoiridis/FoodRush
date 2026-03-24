using FluentValidation.Results;
using Results.Enums;

namespace Results
{
    public class DeleteResult : ResultBase
    {
        private DeleteResult(
        bool success,
        string? failureType = null,
        string? errorDetails = null)
        : base(success, failureType, errorDetails, null)
        {

        }

        public static DeleteResult Ok()
           => new DeleteResult(true);

        public static DeleteResult Fail(string errorDetails, ResultFailureType resultFailure)
           => new DeleteResult(false, resultFailure.ToString(), errorDetails);
    }
}
