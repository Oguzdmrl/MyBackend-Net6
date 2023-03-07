using MediatR;
using Microsoft.AspNetCore.Mvc;
using Business.Managers.ProductEvent.Delete;
using Business.Managers.ProductEvent.Insert;
using Business.Managers.ProductEvent.Select;
using Business.Managers.ProductEvent.Update;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductApiController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductApiController(IMediator mediator) => _mediator = mediator;
        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _mediator.Send(new GetProductQuery()));
        //[HttpGet]
        //public async Task<IActionResult> GetIDProduct([FromBody] GetProductIDQuery param) => Ok(await _mediator.Send(param));

        [HttpPost]
        public async Task<IActionResult> InsertProduct([FromBody] InsertProductCommandQuery param) => Ok(await _mediator.Send(param));

        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductCommandQuery param) => Ok(await _mediator.Send(param));
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct([FromBody] DeleteProductCommandQuery param) => Ok(await _mediator.Send(param));
    }
}