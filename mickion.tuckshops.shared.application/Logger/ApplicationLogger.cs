using Serilog;
using Microsoft.Extensions.DependencyInjection;
using Serilog.Events;

namespace mickion.tuckshops.shared.application.Logger
{
    public static class ApplicationLogger
    {
        public static IServiceCollection AddApplicationLogging(this IServiceCollection services)
        {
            string filename = $"C:\\Logs\\{System.AppDomain.CurrentDomain.FriendlyName}-log-.txt";
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File(filename, rollingInterval: RollingInterval.Day, rollOnFileSizeLimit: true)
                .MinimumLevel.Verbose()
                .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
                .MinimumLevel.Override("Microsoft.Extensions.Hosting", LogEventLevel.Information)
                .MinimumLevel.Override("Microsoft.Hosting", LogEventLevel.Information)
                .CreateLogger();

            services.AddSerilog();

            return services;
        }

    }
}
