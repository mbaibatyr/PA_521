using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using MyMediatR.Product;

namespace MyMediatR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        [EnableRateLimiting("fixed")] // Применяем лимит на создание продукта
        public async Task<IActionResult> Create([FromBody] CreateProductCommand command)
        {
            int id = await mediator.Send(command);
            return Ok(new { Id = id });
        }
    }
}
