using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YourProjectName.Application.CQRS.Authentication.CreateUser;
using YourProjectName.Application.CQRS.Authentication.Login;

namespace YourProjectName.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseAPIController
    {
        public AuthController(IMediator mediator):base(mediator)
        {
            
        }

        [HttpPost]
        [Route("register-user")]
        public async Task<IActionResult> Register(RegisterUserCommand request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost]
        [Route("login-user")]
        public async Task<IActionResult> Login(LoginUserCommand request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
