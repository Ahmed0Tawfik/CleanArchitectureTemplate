using FluentValidation;

namespace YourProjectName.API.Extensions
{
    public static class MediatrServiceExtensions
    {
        public static IServiceCollection AddMediatrServices(this IServiceCollection services)
        {
            services.AddMediatR(
                options => options.RegisterServicesFromAssembly(typeof(Program).Assembly));

            services.AddValidatorsFromAssembly(typeof(Program).Assembly);
            return services;
        }
    }
}
