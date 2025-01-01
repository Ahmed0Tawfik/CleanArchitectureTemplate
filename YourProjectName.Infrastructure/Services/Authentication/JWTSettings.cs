namespace YourProjectName.Infrastructure.Services.Authentication
{
    public class JWTSettings
    {
        public const string SectionName = "JWTSettings";

        public string Secret { get; init; } = default!;
        public string Issuer { get; init; } = default!;
        public string Audience { get; init; } = default!;
        public int ExpiryInMinutes { get; init; }


    }
}
