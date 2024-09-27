using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace mickion.tuckshops.stores.infrastucture
{
    public static class DependencyRegistration
    {
        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services, IConfiguration config)
        {
            // TODO: refactor to IOptions
            //var connectionString = config.GetConnectionString("TuckShopWarehouse");
            //services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

            //services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
