using mickion.tuckshops.shared.application.Exceptions.Handlers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace mickion.tuckshops.shared.application
{
    public static class DependencyRegistration
    {
        public static IServiceCollection AddGlobalExceptionHandler(this IServiceCollection services, IConfiguration config)
        {
            services.AddExceptionHandler<GlobalExceptionHandler>();
            services.AddProblemDetails();

            return services;
        }
    }
}
