using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using PA_521.Abstract;
using PA_521.Model;

namespace PA_521.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        ICity service;
        public CityController(ICity service)
        {
            this.service = service;
        }

        [HttpGet("CityGetAll")]
        public ActionResult CityGetAll()
        {
            return Ok(service.CityGetAll());
        }
    }
}
