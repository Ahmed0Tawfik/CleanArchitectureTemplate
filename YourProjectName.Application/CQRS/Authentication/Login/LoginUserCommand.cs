using MediatR;
using YourProjectName.Application.APIResponse;
using YourProjectName.Application.Services.Authentication;

namespace YourProjectName.Application.CQRS.Authentication.Login
{
    public record LoginUserCommand(string Email, string Password) : IRequest<APIResponse<AuthenticationResponse>>;

}
