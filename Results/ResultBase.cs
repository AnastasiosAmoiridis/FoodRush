using Results.Enums;

namespace Results
{
    public abstract class ResultBase
    {
        public bool Success { get; }

        public string? ErrorDetails { get; }

        public ResultFailureType FailureType { get; } = ResultFailureType.None;

        public IReadOnlyCollection<ValidationError>? ValidationErrors { get; }

        protected ResultBase(
            bool sucess,
            string? errorDetails = null,
            IReadOnlyCollection<ValidationError>? validationErrors = null,
            ResultFailureType failureType = ResultFailureType.None)
        {
            Success = sucess;
            ErrorDetails = errorDetails;
            FailureType = failureType;
            ValidationErrors = validationErrors;
        }
    }
}
