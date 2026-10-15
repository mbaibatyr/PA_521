using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyTest.Abstract;
using MyTest.Model;

namespace MyTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudent _repository;
        public StudentController(IStudent repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var student = await _repository.GetByIdAsync(id);
            if (student == null)
                return NotFound();

            return Ok(student);
        }


        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Student student)
        {
            if (student == null)
                return BadRequest("Данные студента не переданы.");

            await _repository.AddAsync(student);
            return Ok(new { message = "Студент успешно добавлен", student });
        }
    }
}
