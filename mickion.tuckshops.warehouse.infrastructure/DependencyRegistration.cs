
using Microsoft.Extensions.DependencyInjection;
using mickion.tuckshops.warehouse.infrastructure.Repositories.Base;
using mickion.tuckshops.warehouse.domain.Contracts.Repositories.Base;
using Microsoft.Extensions.Configuration;
using mickion.tuckshops.warehouse.infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using mickion.tuckshops.warehouse.domain.Contracts.Repositories;
using mickion.tuckshops.warehouse.infrastructure.Repositories;

namespace mickion.tuckshops.warehouse.infrastructure
{
    public static class DependencyRegistration
    {
        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services, IConfiguration config) 
        {
            RegisterDatabase(services,config);
            RegisterInfrastructureServices(services);
            return services;
        }

        private static void RegisterDatabase(IServiceCollection services, IConfiguration config)
        {
#warning refactor to IOptions
            var connectionString = config.GetConnectionString("TuckShopWarehouse");
            services.AddDbContext<WarehouseDbContext>(options => options.UseSqlServer(connectionString));
        }

        private static void RegisterInfrastructureServices(IServiceCollection services)
        {
            //services.AddScoped<ISharedApplicationDbContext, SharedApplicationDbContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IBrandRepository, BrandRepository>();
        }
    }
}