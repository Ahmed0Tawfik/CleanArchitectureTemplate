using System.Security.Claims;

namespace YourProjectName.Application.Interfaces.Authentication
{
    public interface ITokenService
    {
        string GenerateToken(
            Guid userId,
            string email,
            string firstName,
            string lastName
            );

    }

}
