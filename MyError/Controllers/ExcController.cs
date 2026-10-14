using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyError.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExcController : ControllerBase
    {
        [HttpGet("GetData")]
        public ActionResult GetData(string date)
        {
            return Ok(DateTime.Parse(date));
        }

        [HttpGet("DivideZero")]
        public ActionResult DivideZero(int a)
        {
            return Ok(10 / a);
        }
    }
}
