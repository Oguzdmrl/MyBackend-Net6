using Business.Managers.AuthEvent.Login;
using Business.Managers.AuthEvent.Register;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthApiController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AuthApiController(IMediator mediator) => _mediator = mediator;
        [HttpPost] public async Task<IActionResult> Login([FromBody] LoginQuery param) => Ok(await _mediator.Send(param));
        [HttpPost] public async Task<IActionResult> Register([FromBody] RegisterQuery param) => Ok(await _mediator.Send(param));
    }
}
