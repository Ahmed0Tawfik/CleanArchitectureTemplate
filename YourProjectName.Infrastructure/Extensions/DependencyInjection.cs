using Microsoft.Extensions.DependencyInjection;
using YourProjectName.Application.Interfaces.Authentication;
using YourProjectName.Application.Interfaces.DateTimeProvider;
using Microsoft.Extensions.Configuration;
using YourProjectName.Infrastructure.Services.Authentication;
using YourProjectName.Infrastructure.Services.DateTimeProvider;
using YourProjectName.Infrastructure.Services.UserServices;
using YourProjectName.Application.Interfaces.UserServices;
using YourProjectName.Infrastructure.Identity;
using YourProjectName.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;


namespace YourProjectName.Infrastructure.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {

            // Add Db Context
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // Add Identity Services

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                // Password settings
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings
                // options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                // options.Lockout.MaxFailedAccessAttempts = 5;
                //options.Lockout.AllowedForNewUsers = true;

                // User settings
                options.User.RequireUniqueEmail = true;
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";

                // SignIn settings
                //options.SignIn.RequireConfirmedEmail = true;
            })
                    .AddEntityFrameworkStores<ApplicationDbContext>()
                    .AddDefaultTokenProviders();

            // Register Services
            services.AddSingleton<ITokenService, TokenService>();
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
            services.AddScoped<IUserService, UserService>();


            // Register JWTSettings
            services.Configure<JWTSettings>(configuration.GetSection(JWTSettings.SectionName));
            return services;
        }


    }
}