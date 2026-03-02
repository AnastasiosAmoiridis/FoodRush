using FluentValidation.Results;
using Results;
using Results.Enums;

public sealed class ListResult<T> : ResultBase
{
    public IReadOnlyCollection<T>? Items { get; }

    private ListResult(
        IReadOnlyCollection<T>? items,
        bool success,
        string? failureType = null,
        string? errorDetails = null,
        IReadOnlyCollection<ValidationFailure>? validationErrors = null)
        : base(success, failureType, errorDetails, validationErrors)
    {
        Items = items;
    }

    public static ListResult<T> Ok(IReadOnlyCollection<T> items)
        => new ListResult<T>(items, true);

    public static ListResult<T> Fail(string error, ResultFailureType type)
        => new ListResult<T>(null, false, type.ToString(), error);

    public static ListResult<T> ValidationFail(
        IReadOnlyCollection<ValidationFailure> errors)
        => new ListResult<T>(null, false, ResultFailureType.Validation.ToString(), null, errors);
}