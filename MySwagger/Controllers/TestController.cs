using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MySwagger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet, Route("Get_1")]
        public ActionResult Get_1(int a, int b)
        {
            return Ok(a + b);
        }
    }
}
