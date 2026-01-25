
using Results.Enums;

namespace Results
{
    public class HttpResultBase : ResultBase
    {
        public HttpResultCode Code { get; private set; }

        public void SetSucess()
        {
            base.SetSuccess();
            Code = HttpResultCode.Ok;
        }

        public void FailWithCode(HttpResultCode code, string errorDetails)
        {
            base.Fail(errorDetails);
            Code = code;
        }

        public override void FailWithValidationErrors(ICollection<ValidationError> validationErrors)
        {
            base.FailWithValidationErrors(validationErrors);
            Code = HttpResultCode.BadRequest;
        }
    }
}
