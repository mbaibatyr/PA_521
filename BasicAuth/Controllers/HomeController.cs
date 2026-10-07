using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BasicAuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class HomeController : ControllerBase
    {
        [HttpGet, Route("SayHello")]
        public ActionResult SayHello(string name = "World")
        {
            return Ok($"Hello {name}!");
        }
    }
}
