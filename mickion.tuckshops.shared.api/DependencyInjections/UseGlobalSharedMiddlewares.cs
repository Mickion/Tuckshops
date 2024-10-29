using Microsoft.AspNetCore.Builder;
using Serilog;

namespace mickion.tuckshops.shared.api.DependencyInjections
{
    public static class UseGlobalSharedMiddlewares
    {
        public static WebApplication UseSharedMiddlewares(this WebApplication app)
        {
            app.UseExceptionHandler();

            app.UseSerilogRequestLogging();

            return app;
        }
    }
}
