using Microsoft.Extensions.DependencyInjection;
using YourProjectName.Application.Services.Authentication;

namespace YourProjectName.Application.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();



            return services;
        }

    }
}
