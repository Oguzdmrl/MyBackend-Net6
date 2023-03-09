using Business.Managers.UserEvent.Delete;
using Business.Managers.UserEvent.Insert;
using Business.Managers.UserEvent.Select;
using Business.Managers.UserEvent.Update;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserApiController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserApiController(IMediator mediator) => _mediator = mediator;
        [HttpGet/*, AuthorizationRole("Admin")*/]
        public async Task<IActionResult> GetAll() => Ok(await _mediator.Send(new GetUserQuery()));
        [HttpGet/*, AuthorizationRole("Admin")*/]
        public async Task<IActionResult> GetIDUser([FromBody] GetUserIDQuery param) => Ok(await _mediator.Send(param));

        [HttpPost/*, AuthorizationRole("Admin,Insert")*/]
        public async Task<IActionResult> InsertUser([FromBody] InsertUserCommandQuery param) => Ok(await _mediator.Send(param));

        [HttpPut/*, AuthorizationRole("Admin,Update")*/]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserCommandQuery param) => Ok(await _mediator.Send(param));
        [HttpDelete/*, AuthorizationRole("Admin,Delete")*/]
        public async Task<IActionResult> DeleteUser([FromBody] DeleteUserCommandQuery param) => Ok(await _mediator.Send(param));
    }
}