using FluentValidation.Results;
using Results.Enums;

namespace Results
{
    public abstract class ResultBase
    {
        public bool Success { get; }

        public string? ErrorDetails { get; }

        public string? FailureType { get; }

        public IReadOnlyCollection<ValidationFailure>? ValidationErrors { get; }

        protected ResultBase(
            bool sucess,
            string? failureType = null,
            string? errorDetails = null,
            IReadOnlyCollection<ValidationFailure>? validationErrors = null)
        {
            Success = sucess;
            ErrorDetails = errorDetails;
            FailureType = failureType;
            ValidationErrors = validationErrors;
        }
    }
}
