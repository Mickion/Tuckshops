using mickion.tuckshops.warehouse.domain.Common.Enums;
using mickion.tuckshops.warehouse.domain.Contracts.Services;
using Microsoft.Extensions.Logging;

namespace mickion.tuckshops.warehouse.application.Services.Order
{
    internal class OrderService (ILogger<OrderService> logger): IOrderService
    {
        private readonly ILogger<OrderService> _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        public Task OrderAsync(Guid productId, OrderType orderType)
        {
            _logger.LogInformation($"Placing an order for Product Id {productId}");

            // Get Available quantity on the warehouse
            // If 0 or certain amount, place and order with the brand/supplier
#warning refactor order type 
            if (orderType == OrderType.PilotOrder) 
            {
                Console.WriteLine("Get number of registered stores");
                Console.WriteLine("Order 5 items for each store. Pilot");
            }

            return Task.CompletedTask;
        }

        public Task OrderAsync(Guid productId, OrderType orderType, Guid storeId)
        {
            if (orderType == OrderType.StoreOrder)
            {
                Console.WriteLine("Get available quantity in the store");
                Console.WriteLine("Get item threshold for that particular store");
                Console.WriteLine("Get stats of how fast the product sells in that store");
                Console.WriteLine("Make an X amount of order based on the above stats");
            }

            return Task.CompletedTask;
        }
    }
}
