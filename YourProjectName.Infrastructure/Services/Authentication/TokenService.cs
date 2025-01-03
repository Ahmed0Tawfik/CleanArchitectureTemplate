using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using YourProjectName.Application.Interfaces.Authentication;
using YourProjectName.Application.Interfaces.DateTimeProvider;

namespace YourProjectName.Infrastructure.Services.Authentication
{
    public class TokenService : ITokenService
    {
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly JWTSettings _jwtSettings;
        public TokenService(IDateTimeProvider dateTimeProvider, IOptions<JWTSettings> jwtOptions)
        {
            _dateTimeProvider = dateTimeProvider;
            _jwtSettings = jwtOptions.Value;
        }

        public string GenerateToken(
            string userId,
            string email,
            string username
            )
        {
            var Signingkey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_jwtSettings.Secret)
                );

            var signingCredentials = new SigningCredentials(
                Signingkey,
                SecurityAlgorithms.HmacSha256Signature
                );

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, userId),
                new Claim(JwtRegisteredClaimNames.Email, email),
                new Claim(JwtRegisteredClaimNames.PreferredUsername, username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())

            };

            var securityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                signingCredentials: signingCredentials,
                expires: _dateTimeProvider.UtcNow.AddMinutes(_jwtSettings.ExpiryInMinutes)
                );

            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }
    }
}
