using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace mickion.tuckshops.shared.infrastructure
{
    public static class DependencyRegistration
    {
        public static IServiceCollection AddSharedInfrastructureServices(this IServiceCollection services, IConfiguration config)
        {
            return services;
        }
    }
}
