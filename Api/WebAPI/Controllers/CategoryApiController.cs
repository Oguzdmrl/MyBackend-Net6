using Business.Authorization;
using Business.Managers.CategoryEvent.Insert;
using Business.Managers.CategoryEvent.Select;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryApiController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CategoryApiController(IMediator mediator) => _mediator = mediator;

        [HttpGet/*, AuthorizationRole("Admin,User")*/] public async Task<IActionResult> GetAll() => Ok(await _mediator.Send(new GetCategoryQuery()));

        [HttpPost/*, AuthorizationRole("Admin,Insert")*/] public async Task<IActionResult> InsertCategory([FromBody] InsertCategoryCommandQuery param) => Ok(await _mediator.Send(param));
    }
}