namespace YourProjectName.Application.Services.Authentication
{
    public class AuthenticationResponse
    {
        public string Token { get; set; } = string.Empty;
        public int ExpiresIn { get; set; } = 0;
        public DateTime ExpiresAt { get; set; }
        public string RefreshToken { get; set; } = string.Empty;
    }
}
