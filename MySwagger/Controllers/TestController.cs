using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MySwagger.Controllers
{    
    [ApiController]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/my_test")]
    [Tags("Группа 1 (Управление товарами)")]    
    public class TestController : ControllerBase
    {

        /// <summary>
        /// метод сложения двух параметров
        /// </summary>
        /// <param name="a">Первое число</param>
        /// <param name="b">Второе число</param>
        /// <remarks>
        /// Возвращает базовый массив товаров версии 1.0. 
        /// Обратите внимание, что этот метод устаревает, рекомендуется использовать версию 2.0.
        /// </remarks>
        /// <response code="200">Успешно возвращен список продуктов</response>
        /// <response code="400">Ошибка в параметрах запроса</response>        
        [HttpGet, Route("Get_1")]
        [MapToApiVersion("1.0")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public ActionResult Get_1(int a, int b)
        {
            if (a <= 0 || b <= 0)
                return BadRequest("Одно из чисел меньше или равно нулю");
            return Ok(a + b);
        }
    }
}
