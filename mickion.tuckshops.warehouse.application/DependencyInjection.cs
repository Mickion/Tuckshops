
using Microsoft.Extensions.DependencyInjection;

namespace mickion.tuckshops.warehouse.application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services) 
        {
            return services;
        }
    }
}