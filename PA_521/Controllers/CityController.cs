using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using PA_521.Abstract;
using PA_521.Model;
using PA_521.Service;
using System.Reflection;

namespace PA_521.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        ICity service;
        private readonly IMapper _mapper;
        public CityController(ICity service, IMapper mapper)
        {
            this.service = service;
            _mapper = mapper;
            //var model1 = new Model1
            //{
            //    a = "value A",
            //    b = "value B"
            //};

            //var model2 = _mapper.Map<Model2>(model1);
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

        [HttpGet("Test")]
        public IActionResult Test()
        {
            var model1 = new Model1
            {
                a = "AAA",
                b = "BBB"
            };

            var model2 = _mapper.Map<Model2>(model1);

            return Ok(model2);
        }

        [HttpGet("Test2")]
        public IActionResult Test2()
        {
            var model3 = new Model3
            {
                a = "Иван",
                b = "Описание"
            };

            var model4 = _mapper.Map<Model4>(model3);
            return Ok(model4);
        }
    }
}


/*
 sql

alter proc CityDelete
@id int
as
delete from city
where id = @id


select *
from city

insert into city (name, [year], population)
values ('test', 2026, 1000)

exec CityDelete 4

 
 */