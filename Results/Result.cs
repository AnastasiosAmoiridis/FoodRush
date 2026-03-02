using FluentValidation.Results;
using Results.Enums;

namespace Results
{
    public class Result<T> : ResultBase where T : class
    {
        public T? Item { get; protected set; }

        private Result(
        T? item,
        bool success,
        string? failureType = null,
        string? errorDetails = null,
        IReadOnlyCollection<ValidationFailure>? validationErrors = null)
        : base(success, failureType, errorDetails, validationErrors)
        {
            Item = item;
        }

        public static Result<T> Ok(T item)
            => new Result<T>(item, true);

        public static Result<T> Fail(string errorDetails, ResultFailureType resultFailure)
            => new Result<T>(default, false, resultFailure.ToString(), errorDetails);

        public static Result<T> ValidationFail(IReadOnlyCollection<ValidationFailure> validationErrors)
            => new Result<T>(default, false, ResultFailureType.Validation.ToString(), null, validationErrors);
    }
}
