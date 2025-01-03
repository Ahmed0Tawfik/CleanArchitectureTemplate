using System.Security.Claims;

namespace YourProjectName.Application.Interfaces.Authentication
{
    public interface ITokenService
    {
        string GenerateToken(
            string userId,
            string email,
            string username
            );

    }

}
