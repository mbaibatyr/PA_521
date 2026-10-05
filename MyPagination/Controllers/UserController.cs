using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyPagination.Abstract;
using MyPagination.Model;

namespace MyPagination.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUser service;
        public UserController(IUser service) 
        { 
            this.service = service;
        }
        [HttpGet, Route("GetUsers")]
        public async Task<ActionResult> GetUsersAsync(int page = 1, int pageSize = 20)
        {
            var result =  await service.GetUsersAsync(page, pageSize);
            return Ok(result);
        }
    }
}
