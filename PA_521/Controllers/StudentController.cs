using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PA_521.Abstract;

namespace PA_521.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        IStudent service;
        public StudentController(IStudent service)
        {
            this.service = service;
        }

        [HttpGet("GetConcat/{a}/{b}")]
        public ActionResult GetConcat(string a, string b)
        {
            return Ok(service.GetConcat(a, b));
        }
    }
}
