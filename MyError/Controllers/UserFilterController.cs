using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyError.Model;

namespace MyError.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserFilterController : ControllerBase
    {
        [HttpPost]
        public IActionResult Create(User user)
        {
            // Если код выполняется, валидация уже пройдена.
            // Здесь сохранение пользователя в БД.

            return StatusCode(201, new
            {
                message = "Пользователь создан"
            });
        }
    }
}
