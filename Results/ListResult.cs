using Results;
using Results.Enums;

public sealed class ListResult<T> : ResultBase
{
    public IReadOnlyCollection<T>? Items { get; }

    private ListResult(
        IReadOnlyCollection<T>? items,
        bool success,
        ResultFailureType failureType = ResultFailureType.None,
        string? errorDetails = null,
        IReadOnlyCollection<ValidationError>? validationErrors = null)
        : base(success,errorDetails,validationErrors,failureType)
    {
        Items = items;
    }

    public static ListResult<T> Ok(IReadOnlyCollection<T> items)
        => new ListResult<T>(items, true);

    public static ListResult<T> Fail(string error, ResultFailureType type)
        => new ListResult<T>(null, false, type, error);

    public static ListResult<T> ValidationFail(
        IReadOnlyCollection<ValidationError> errors)
        => new ListResult<T>(null, false, ResultFailureType.Validation, null, errors);
}