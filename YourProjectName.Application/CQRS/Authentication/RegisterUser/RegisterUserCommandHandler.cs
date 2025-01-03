using MediatR;
using YourProjectName.Application.APIResponse;
using YourProjectName.Application.Services.Authentication;

namespace YourProjectName.Application.CQRS.Authentication.CreateUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, APIResponse<AuthenticationResponse>>
    {
        private readonly IAuthenticationService _AuthService;
        private readonly APIResponseHandler aPIResponseHandler;
        public RegisterUserCommandHandler(IAuthenticationService authService, APIResponseHandler aPIResponseHandler)
        {
            _AuthService = authService;
            this.aPIResponseHandler = aPIResponseHandler;
        }
        public async Task<APIResponse<AuthenticationResponse>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var response = await _AuthService.RegisterAsync(request.Email, request.Username, request.Password);

            return aPIResponseHandler.CreateSuccessResponse<AuthenticationResponse>(response,"Account Created");


        }
    }
}
