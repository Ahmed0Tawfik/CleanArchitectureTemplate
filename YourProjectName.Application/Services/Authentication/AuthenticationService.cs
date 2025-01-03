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

        public async Task<AuthenticationResponse> LoginAsync(string email, string password)
        {
            var existinguser = await _userService.CheckPasswordAsync(new ApplicationUserDTO { Email = email, Password = password });

            if(existinguser != null)
            {
                return new AuthenticationResponse
                {
                    Token = _tokenService.GenerateToken(existinguser.Id, existinguser.Email, existinguser.UserName),
                    ExpiresAt = DateTime.Now.AddHours(3),
                    ExpiresIn = 3,
                    //RefreshToken = _tokenService.GenerateRefreshToken()
                };
            }

            throw new Exception("Invalid credentials");

        }

        public async Task<AuthenticationResponse> RegisterAsync(string email, string username, string password)
        {
            var result = await _userService.CreateAsync(new ApplicationUserDTO { Email = email, UserName = username, Password = password });

            if (result != null)
            {
                return new AuthenticationResponse
                {
                    Token = _tokenService.GenerateToken(result.Id, result.Email, result.UserName),
                    ExpiresAt = DateTime.Now.AddHours(3),
                    ExpiresIn = 3,
                    //RefreshToken = _tokenService.GenerateRefreshToken()
                };
            }

            throw new Exception("Invalid credentials");
        }
    }
}
