using MediatR;
using YourProjectName.Application.APIResponse;
using YourProjectName.Application.Services.Authentication;

namespace YourProjectName.Application.CQRS.Authentication.CreateUser
{
    public record RegisterUserCommand(string Email,string Username, string Password) : IRequest<APIResponse<AuthenticationResponse>>;
    
}
