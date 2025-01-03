namespace YourProjectName.Application.Interfaces.UserServices
{
    public interface IUserService
    {
        Task<ApplicationUserDTO> FindUserByEmailAsync(string email);
        Task<ApplicationUserDTO> FindUserByIdAsync(string id);
        Task<ApplicationUserDTO> CreateAsync(ApplicationUserDTO user);
        Task<ApplicationUserDTO> CheckPasswordAsync(ApplicationUserDTO user);

    }
}
