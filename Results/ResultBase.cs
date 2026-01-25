namespace Results
{
    public abstract class ResultBase
    {
        public bool Success { get; private set; }

        public string? ErrorDetails { get; private set; }

        public bool HasValidationErrors => ValidationErrors != null && ValidationErrors.Count > 0;

        public ICollection<ValidationError>? ValidationErrors { get; private set; }

        public virtual void SetSuccess()
        {
            Success = true;
        }

        public virtual void Fail(string errorDetails)
        {
            Success = false;
            ErrorDetails = errorDetails;
        }

        public virtual void FailWithValidationErrors(ICollection<ValidationError> validationErrors)
        {
            Success = false;
            ValidationErrors = validationErrors;
        }
    }
}
