using CQRS.API.Models;
using CQRS.Application.Exceptions;
using System.Net;

namespace CQRS.API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var statusCode = HttpStatusCode.InternalServerError;
            object problem = ex switch
            {
                BadRequestException badRequest => new CustomValidationProblemDetail
                {
                    Title = badRequest.Message,
                    Status = (int)HttpStatusCode.BadRequest,
                    Detail = badRequest.InnerException?.Message,
                    Type = nameof(BadRequestException),
                    Errors = badRequest.ValidationErrors
                },
                NotFoundException notFound => new CustomValidationProblemDetail
                {
                    Title = notFound.Message,
                    Status = (int)HttpStatusCode.NotFound,
                    Detail = notFound.InnerException?.Message,
                    Type = nameof(NotFoundException)
                },
                _ => new CustomValidationProblemDetail
                {
                    Title = ex.Message,
                    Status = (int)HttpStatusCode.InternalServerError,
                    Type = nameof(HttpStatusCode.InternalServerError),
                    Detail = ex.StackTrace
                },
            };
            context.Response.StatusCode = (int)statusCode;
            await context.Response.WriteAsJsonAsync(problem);
        }
    }
}
