using Microsoft.Extensions.Hosting;
using Serilog;

namespace YourProjectName.Infrastructure.Logging
{
    public static class SerilogBehavior
    {
        public static void SerilogConfiguration(this IHostBuilder host)
        {
            host.UseSerilog((context, loggerConfig) =>
            {
                loggerConfig.ReadFrom.Configuration(context.Configuration);
            });


        }

    }
}
