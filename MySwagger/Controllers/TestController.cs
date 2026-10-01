using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MySwagger.Controllers
{    
    [ApiController]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/my_test")]
    //[Tags("Группа 1 (Управление товарами)")]    
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        [Tags("Группа 1 (Управление группами)")]
        //[ApiExplorerSettings(IgnoreApi = true)]
        public ActionResult Get_1(int a, int b)
        {
            if (a <= 0 || b <= 0)
            {
                var error = new ErrorResponse
                {
                    ErrorCode = "INCORRECT_DATA_IN",
                    Message = "Одно из чисел меньше или равно нулю",
                    Timestamp = DateTime.UtcNow
                };
                return BadRequest(error);                
            }
            return Ok(a + b);
        }

        [Tags("Группа 1_1 (Управление группами)")]
        [HttpGet, Route("Get_1_1")]
        public ActionResult Get_1_1(int a, int b)
        {
            return Ok(a * b);
        }
        [Tags("Группа 1_1 (Управление группами)")]
        [HttpGet, Route("Get_1_2")]
        public ActionResult Get_1_2(int a, int b)
        {
            return Ok(a * b);
        }
        [Tags("Группа 1_1 (Управление группами)")]
        [HttpGet, Route("Get_1_3")]
        //[ApiExplorerSettings(IgnoreApi = true)]
        public ActionResult Get_1_3(int a, int b)
        {
            return Ok(a * b);
        }



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
        [HttpGet, Route("Get_2")]
        [MapToApiVersion("2.0")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public ActionResult Get_2(int a, int b)
        {
            if (a <= 0 || b <= 0)
            {
                var error = new ErrorResponse
                {
                    ErrorCode = "INCORRECT_DATA_IN",
                    Message = "Одно из чисел меньше или равно нулю",
                    Timestamp = DateTime.UtcNow
                };
                return BadRequest(error);
            }
            return Ok(a + b);
        }
    }
}
