using Business.Managers.RoleEvent.Delete;
using Business.Managers.RoleEvent.Insert;
using Business.Managers.RoleEvent.Select;
using Business.Managers.RoleEvent.Update;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RoleApiController : ControllerBase
    {
        private readonly IMediator _mediator;
        public RoleApiController(IMediator mediator) => _mediator = mediator;
        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _mediator.Send(new GetRoleQuery()));
        //[HttpGet]
        //public async Task<IActionResult> GetIDRole([FromBody] GetRoleIDQuery param) => Ok(await _mediator.Send(param));

        [HttpPost]
        public async Task<IActionResult> InsertRole([FromBody] InsertRoleCommandQuery param) => Ok(await _mediator.Send(param));

        [HttpPut]
        public async Task<IActionResult> UpdateRole([FromBody] UpdateRoleCommandQuery param) => Ok(await _mediator.Send(param));
        [HttpDelete]
        public async Task<IActionResult> DeleteRole([FromBody] DeleteRoleCommandQuery param) => Ok(await _mediator.Send(param));
    }
}