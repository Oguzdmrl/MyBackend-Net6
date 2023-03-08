using Business.Managers.UserRoleEvent.Delete;
using Business.Managers.UserRoleEvent.Insert;
using Business.Managers.UserRoleEvent.Select;
using Business.Managers.UserRoleEvent.Update;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserRoleApiController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserRoleApiController(IMediator mediator) => _mediator = mediator;
        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _mediator.Send(new GetUserRoleQuery()));
        //[HttpGet]
        //public async Task<IActionResult> GetIDUserRole([FromBody] GetUserRoleIDQuery param) => Ok(await _mediator.Send(param));

        [HttpPost]
        public async Task<IActionResult> InsertUserRole([FromBody] InsertUserRoleCommandQuery param) => Ok(await _mediator.Send(param));

        [HttpPut]
        public async Task<IActionResult> UpdateUserRole([FromBody] UpdateUserRoleCommandQuery param) => Ok(await _mediator.Send(param));
        [HttpDelete]
        public async Task<IActionResult> DeleteUserRole([FromBody] DeleteUserRoleCommandQuery param) => Ok(await _mediator.Send(param));
    }
}