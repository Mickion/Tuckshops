
using FluentValidation;
using mickion.tuckshops.warehouse.application.Features.Brands.Commands.Create;
using mickion.tuckshops.warehouse.application.Services.Order;
using mickion.tuckshops.warehouse.domain.Contracts.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace mickion.tuckshops.warehouse.application
{
    public static class DependencyRegistration
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services) 
        {
            RegisterMediatR(services);
            RegisterFluentValidators(services);
            RegisterApplicationServices(services);
            return services;
        }

        /// <summary>
        /// Registers MediatR 
        /// </summary>
        /// <param name="services"></param>
        private static void RegisterMediatR(IServiceCollection services) =>
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));        

        /// <summary>
        /// Registers all fluent validators
        /// </summary>
        /// <param name="services"></param>
        private static void RegisterFluentValidators(IServiceCollection services)
        {
            services.AddScoped<IValidator<CreateBrandCommand>, CreateBrandValidator>();            
        }

        private static void RegisterApplicationServices(IServiceCollection services) 
        {
            services.AddScoped<IOrderService, OrderService>();
        }
        
    }
}