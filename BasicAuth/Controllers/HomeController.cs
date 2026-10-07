using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BasicAuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class HomeController : ControllerBase
    {
        [HttpGet, Route("SayHelloAdmin")]
        [Authorize(Roles = "Admin")]
        public ActionResult SayHelloAdmin(string name = "World")
        {
            return Ok($"Hello {name}!");
        }

        [HttpGet, Route("SayHelloUser")]
        [Authorize(Roles = "User")]
        public ActionResult SayHelloUser(string name = "World")
        {
            return Ok($"Hello {name}!");
        }

        [HttpGet, Route("SayHelloAll")]
        [Authorize]
        public ActionResult SayHelloAll(string name = "World")
        {
            return Ok($"Hello {name}!");
        }

        [HttpGet, Route("SayHelloAnonymous")]
        [AllowAnonymous]
        public ActionResult SayHelloAnonymous(string name = "World")
        {
            return Ok($"Hello {name}!");
        }
    }
}
