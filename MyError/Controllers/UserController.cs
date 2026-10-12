using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyError.Model;
using System.Threading;

namespace MyError.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IValidator<User> _validator;

        public UserController(IValidator<User> validator)
        {
            _validator = validator;
        }

        [HttpPost("UserAdd")]
        public async Task<ActionResult> UserAddAsync(User user, CancellationToken cancellationToken)
        {
            var result = await _validator.ValidateAsync(user, cancellationToken);

            if (!result.IsValid)
            {
                var errors = result.Errors
                    .GroupBy(x => x.PropertyName)
                    .ToDictionary(
                        g => g.Key,
                        g => g.Select(x => x.ErrorMessage).ToArray());

                return BadRequest(new ValidationProblemDetails
                {
                    Errors = errors,
                    Status = StatusCodes.Status400BadRequest,
                    Title = "Ошибка валидации"
                });
            }

            // Здесь сохранение пользователя в БД.

            return StatusCode(201, new
            {
                message = "Пользователь создан"
            });

        }
    }
}
