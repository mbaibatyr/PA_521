using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MyError.Filter
{
    public class FluentValidationFilter : IAsyncActionFilter
    {
        private readonly IServiceProvider _services;

        public FluentValidationFilter(IServiceProvider services)
        {
            _services = services;
        }

        public async Task OnActionExecutionAsync(
            ActionExecutingContext context,
            ActionExecutionDelegate next)
        {
            var failures = new List<ValidationFailure>();

            foreach (var argument in context.ActionArguments.Values)
            {
                if (argument is null)
                    continue;

                var validatorType = typeof(IValidator<>)
                    .MakeGenericType(argument.GetType());

                if (_services.GetService(validatorType)
                    is not IValidator validator)
                    continue;

                var validationContext =
                    new ValidationContext<object>(argument);

                var result = await validator.ValidateAsync(
                    validationContext,
                    context.HttpContext.RequestAborted);

                failures.AddRange(result.Errors);
            }

            if (failures.Count > 0)
            {
                var errors = failures
                    .GroupBy(x => x.PropertyName)
                    .ToDictionary(
                        g => g.Key,
                        g => g.Select(x => x.ErrorMessage).ToArray());

                var problem = new ValidationProblemDetails(errors)
                {
                    Status = StatusCodes.Status400BadRequest,
                    Title = "Ошибка валидации",
                    Type = "https://tools.ietf.org/html/rfc9110#section-15.5.1",
                    Instance = context.HttpContext.Request.Path
                };

                context.Result = new BadRequestObjectResult(problem);
                return;
            }

            await next();
        }
    }
}