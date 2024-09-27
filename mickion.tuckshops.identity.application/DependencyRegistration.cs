using Microsoft.Extensions.DependencyInjection;

namespace mickion.tuckshops.identity.application
{
    public static class DependencyRegistration
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            return services;
        }
    }
}
