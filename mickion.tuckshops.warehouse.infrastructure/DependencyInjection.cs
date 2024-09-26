
using Microsoft.Extensions.DependencyInjection;
using mickion.tuckshops.warehouse.infrastructure.Repositories.Base;
using mickion.tuckshops.warehouse.domain.Contracts.Repositories.Base;

namespace mickion.tuckshops.warehouse.infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services) 
        {            
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}