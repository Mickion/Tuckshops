
using Microsoft.Extensions.DependencyInjection;

namespace mickion.tuckshops.warehouse.application
{
    public static class DependencyRegistration
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services) 
        {
            return services;
        }
    }
}