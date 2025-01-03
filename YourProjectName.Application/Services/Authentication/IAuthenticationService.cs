namespace YourProjectName.Application.Services.Authentication
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResponse> LoginAsync(string email, string password);
        Task<AuthenticationResponse> RegisterAsync(string email, string username, string password);
    }
}
