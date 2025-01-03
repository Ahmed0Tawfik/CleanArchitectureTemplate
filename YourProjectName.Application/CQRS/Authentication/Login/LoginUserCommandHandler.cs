using MediatR;
using YourProjectName.Application.APIResponse;
using YourProjectName.Application.Services.Authentication;

namespace YourProjectName.Application.CQRS.Authentication.Login
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, APIResponse<AuthenticationResponse>>
    {
        private readonly IAuthenticationService _AuthService;
        private readonly APIResponseHandler aPIResponseHandler;
        public LoginUserCommandHandler(IAuthenticationService authService, APIResponseHandler aPIResponseHandler)
        {
            _AuthService = authService;
            this.aPIResponseHandler = aPIResponseHandler;
        }
        public async Task<APIResponse<AuthenticationResponse>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var response = await _AuthService.LoginAsync(request.Email, request.Password);

            return aPIResponseHandler.CreateSuccessResponse<AuthenticationResponse>(response, "Login Successful");

        }
    }
}
