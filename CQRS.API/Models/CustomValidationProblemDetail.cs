using Microsoft.AspNetCore.Mvc;

namespace CQRS.API.Models
{
    public class CustomValidationProblemDetail : ProblemDetails
    {
        public IDictionary<string, string[]> Errors { get; set; }
    }
}
