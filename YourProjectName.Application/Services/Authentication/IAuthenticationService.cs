namespace YourProjectName.Application.Services.Authentication
{
    public interface IAuthenticationService
    {
        AuthenticationResponse Login(
            string email,
            string password
            );


        AuthenticationResponse Register(
            string email,
            string password
            );
    }
}
