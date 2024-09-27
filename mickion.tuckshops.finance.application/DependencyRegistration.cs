using Microsoft.Extensions.DependencyInjection;

namespace mickion.tuckshops.finance.application
{
    public static class DependencyRegistration
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            return services;
        }
    }
}
