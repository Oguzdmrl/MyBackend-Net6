using Business.Managers.UserRoleEvent.Delete;
using Business.Managers.UserRoleEvent.Insert;
using Business.Managers.UserRoleEvent.Select;
using Business.Managers.UserRoleEvent.Update;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserRoleApiController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserRoleApiController(IMediator mediator) => _mediator = mediator;
        [HttpGet/*, AuthorizationRole("Admin")*/]
        public async Task<IActionResult> GetAll() => Ok(await _mediator.Send(new GetUserRoleQuery()));
        [HttpGet/*, AuthorizationRole("Admin")*/]
        public async Task<IActionResult> GetIDUserRole([FromBody] GetUserRoleIDQuery param) => Ok(await _mediator.Send(param));

        [HttpPost/*, AuthorizationRole("Admin,Insert")*/]
        public async Task<IActionResult> InsertUserRole([FromBody] InsertUserRoleCommandQuery param) => Ok(await _mediator.Send(param));

        [HttpPut/*, AuthorizationRole("Admin,Update")*/]
        public async Task<IActionResult> UpdateUserRole([FromBody] UpdateUserRoleCommandQuery param) => Ok(await _mediator.Send(param));
        [HttpDelete/*, AuthorizationRole("Admin,Delete")*/]
        public async Task<IActionResult> DeleteUserRole([FromBody] DeleteUserRoleCommandQuery param) => Ok(await _mediator.Send(param));
    }
}