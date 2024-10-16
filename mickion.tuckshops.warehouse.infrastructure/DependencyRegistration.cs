
using Microsoft.Extensions.DependencyInjection;
using mickion.tuckshops.warehouse.infrastructure.Repositories.Base;
using mickion.tuckshops.warehouse.domain.Contracts.Repositories.Base;
using Microsoft.Extensions.Configuration;
using mickion.tuckshops.warehouse.infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using mickion.tuckshops.shared.infrastructure.Persistence;

namespace mickion.tuckshops.warehouse.infrastructure
{
    public static class DependencyRegistration
    {
        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services, IConfiguration config) 
        {
            // TODO: refactor to IOptions
            var connectionString = config.GetConnectionString("TuckShopWarehouse");
            services.AddDbContext<WarehouseDbContext>(options => options.UseSqlServer(connectionString));

            services.AddScoped<ISharedApplicationDbContext, SharedApplicationDbContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}