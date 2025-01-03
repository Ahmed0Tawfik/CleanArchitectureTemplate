using FluentValidation;
using System.Reflection;
using YourProjectName.Application.CQRS.Authentication.CreateUser;

namespace YourProjectName.API.Extensions
{
    public static class MediatrServiceExtensions
    {
        public static IServiceCollection AddMediatrServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
                            cfg.RegisterServicesFromAssemblies(
                            Assembly.GetAssembly(typeof(RegisterUserCommand)),
                            Assembly.GetAssembly(typeof(RegisterUserCommandHandler))));

            services.AddValidatorsFromAssembly(typeof(Program).Assembly);
            return services;
        }
    }
}
