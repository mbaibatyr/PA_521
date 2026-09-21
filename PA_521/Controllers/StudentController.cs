using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PA_521.Abstract;
using PA_521.Model;
using System.Reflection;

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

        [HttpGet("GetSum/{a}/{b}")]
        public ActionResult GetSum(int a, int b)
        {
            return Ok(service.GetSum(a, b));
        }

        [HttpPost("PostConcat")]
        public ActionResult PostConcat(PostConcatModel model)
        {
            return Ok(service.GetConcat(model.a, model.b));
        }

        [HttpPost("PostGetConcat/{id}")]
        public ActionResult PostGetConcat(PostConcatModel model, string id)
        {
            return Ok(service.GetConcat(model.a, model.b + id));
        }

        [HttpPut("PutConcat")]
        public ActionResult PutConcat(PostConcatModel model)
        {
            return Ok(service.GetConcat(model.a, model.b));
        }

        [HttpDelete("DeleteConcat/{id}")]
        public ActionResult DeleteConcat(string id)
        {
            return Ok(service.GetConcat(id, id));
        }
    }
}
