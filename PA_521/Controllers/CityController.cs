using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using PA_521.Abstract;
using PA_521.Model;
using PA_521.Service;

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

        [HttpDelete("CityDelete/{id}")]
        public ActionResult CityDelete(int id)
        {            
            return Ok(service.CityDelete(id));
        }        
    }
}
