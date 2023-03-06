using MediatR;
using Microsoft.AspNetCore.Mvc;
using Services.Managers.CategoryEvent.Insert;
using Services.Managers.CategoryEvent.Select;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryApiController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CategoryApiController(IMediator mediator) => _mediator = mediator;
        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _mediator.Send(new GetCategoryQuery()));

        [HttpPost]
        public async Task<IActionResult> InsertCategory([FromBody] InsertCategoryCommandQuery param) => Ok(await _mediator.Send(param));
    }
}