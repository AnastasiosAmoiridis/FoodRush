using Results.Enums;

namespace Results
{
    public class Result<T> : ResultBase where T : class
    {
        public T? Item { get; protected set; }

        private Result(
        T? item,
        bool success,
        ResultFailureType failureType = ResultFailureType.None,
        string? errorDetails = null,
        IReadOnlyCollection<ValidationError>? validationErrors = null)
        : base(success, errorDetails, validationErrors, failureType)
        {
            Item = item;
        }

        public static Result<T> Ok(T item)
            => new Result<T>(item, true);

        public static Result<T> Fail(string errorDetails, ResultFailureType resultFailure)
            => new Result<T>(default, false, resultFailure, errorDetails);

        public static Result<T> ValidationFail(IReadOnlyCollection<ValidationError> validationErrors)
            => new Result<T>(default, false, ResultFailureType.Validation, null, validationErrors);
    }
}
