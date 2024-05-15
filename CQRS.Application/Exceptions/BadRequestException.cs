
using FluentValidation.Results;

namespace CQRS.Application.Exceptions
{
    public class BadRequestException : Exception
    {
        public IDictionary<string, string[]> ValidationErrors { get; set; }

        public BadRequestException(string msg) : base(msg) { }

        public BadRequestException(string msg, ValidationResult result) : base(msg)
        {
            ValidationErrors = result.ToDictionary();
        }
    }
}
