using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyError.Model;

namespace MyError.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //private readonly IValidator<User> _validator;

        //public UserController(IValidator<User> validator)
        //{
        //    _validator = validator;
        //}

        [HttpPost("UserAdd")]
        public ActionResult UserAdd(User user)
        {
            /*
             обращение в БД по созданию
             */
            return Created("", user);
        }
    }
}
