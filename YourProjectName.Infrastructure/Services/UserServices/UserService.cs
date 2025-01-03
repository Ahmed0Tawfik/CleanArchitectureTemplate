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
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            if (string.IsNullOrEmpty(user.Password))
            {
                throw new ArgumentException("Password cannot be null or empty.", nameof(user.Password));
            }

            var newuser = new ApplicationUser
            {
                Email = user.Email,
                UserName = user.UserName
                // Other properties as needed
            };

            var result = await _userManager.CreateAsync(newuser, user.Password);

            if (result.Succeeded)
            {


                var userDtoResponse = new ApplicationUserDTO
                {
                    Id = newuser.Id,
                    Email = newuser.Email,
                    UserName = newuser.UserName
                    // Exclude PasswordHash and other sensitive fields
                };
                return userDtoResponse;
            }
            else
            {
                throw new InvalidOperationException($"User creation failed. Errors: {string.Join(", ", result.Errors.Select(e => e.Description))}");
            }
        }
        public async Task<ApplicationUserDTO> CheckPasswordAsync(ApplicationUserDTO user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            var existinguser = await _userManager.FindByEmailAsync(user.Email);

            if (user != null && await _userManager.CheckPasswordAsync(existinguser, user.Password))
            {
                var userDtoResponse = new ApplicationUserDTO
                {
                    Id = existinguser.Id,
                    Email = existinguser.Email,
                    UserName = existinguser.UserName
                    // Exclude PasswordHash and other sensitive fields
                };
                return userDtoResponse;
            }
            return null;
        }
        public async Task<ApplicationUserDTO> FindUserByEmailAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null)
            {
                var userDto = new ApplicationUserDTO
                {
                    Id = user.Id,
                    Email = user.Email,
                    UserName = user.UserName
                    // Exclude PasswordHash and other sensitive fields
                };
                return userDto;
            }
            return null;

        }
        public async Task<ApplicationUserDTO> FindUserByIdAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                var userDto = new ApplicationUserDTO
                {
                    Id = user.Id,
                    Email = user.Email,
                    UserName = user.UserName
                    // Exclude PasswordHash and other sensitive fields
                };
                return userDto;
            }
            return null;
        }
    }
}
