using System.Text.RegularExpressions;

namespace Results
{
    public class ValidationError
    {
        public required string PropertyName { get; set; }

        public required string Message { get; set; }

        public Object? ExcpectedValue { get; set; }
    }
}
