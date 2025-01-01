using YourProjectName.Application.Interfaces.Authentication;
using YourProjectName.Application.Interfaces.UserServices;

namespace YourProjectName.Application.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly ITokenService _tokenService;
        private readonly IUserService _userService;

        public AuthenticationService(ITokenService tokenService, IUserService userService)
        {
            _tokenService = tokenService;
            _userService = userService;
        }

        public AuthenticationResponse Login(string email, string password)
        {
            // Check if User exists and passwords match 

            // Create Token



            return new AuthenticationResponse(Guid.NewGuid(), email, "token");
        }

        public AuthenticationResponse Register(string email, string password)
        {
            // Check if User Already exists

            // Create User

            // Create Token

            //var token = _tokenService.GenerateToken(Guid.NewGuid(), email);

            return null;




        }
    }
}
