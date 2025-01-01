using Microsoft.AspNetCore.Identity;
using Microsoft.Identity.Client;
using YourProjectName.Application.Interfaces.UserServices;
using YourProjectName.Infrastructure.Identity;

namespace YourProjectName.Infrastructure.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<ApplicationUserDTO> CreateAsync(ApplicationUserDTO user)
        {
            var applicationUser = new ApplicationUser
            {
                Email = user.Email,
                UserName = user.Email,
            };

            var result = await _userManager.CreateAsync(applicationUser, user.Password);

            if (result.Succeeded)
            {
                return new ApplicationUserDTO
                {
                    Id = applicationUser.Id,
                    Email = applicationUser.Email,
                    Username = applicationUser.UserName
                };
            }
            else
            {
                throw new InvalidOperationException(
                    "User creation failed.",
                    new Exception(result.Errors.ToString())
                    );
            }

        }

        public async Task<ApplicationUserDTO> FindUserByEmailAsync(string email)
        {
            var result = await _userManager.FindByEmailAsync(email);

            if (result != null)
            {
                return new ApplicationUserDTO
                {
                    Id = result.Id,
                    Email = result.Email,
                    Username = result.UserName
                };
            }
            else
            {
                throw new InvalidOperationException("User not found."); 
            }

        }

        public Task<ApplicationUserDTO> FindUserByIdAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}
