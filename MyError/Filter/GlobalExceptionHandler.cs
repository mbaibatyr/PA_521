using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace MyError.Filter
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(
            ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
        }
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            _logger.LogError(
                      exception,
                      "Unhandled exception. TraceId: {TraceId}",
                      httpContext.TraceIdentifier);

            var problem = new ProblemDetails
            {
                Status = StatusCodes.Status500InternalServerError,
                Title = "Внутренняя ошибка сервера",
                Detail = "Произошла непредвиденная ошибка.",
                Instance = httpContext.Request.Path,
                Type = exception.GetType().Name
            };

            problem.Extensions["traceId"] = httpContext.TraceIdentifier;

            httpContext.Response.StatusCode = problem.Status!.Value;

            httpContext.Response.ContentType = "application/problem+json";

            await httpContext.Response.WriteAsJsonAsync(
                problem,
                cancellationToken);

            return true;
        }
    }
}