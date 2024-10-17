using MediatR;
using Microsoft.Extensions.Logging;
using mickion.tuckshops.warehouse.domain.Contracts.Services;

namespace mickion.tuckshops.warehouse.application.Features.Product.Events
{
    internal class ProductCreatedEventHandler(ILogger<ProductCreatedEventHandler> logger, 
        IOrderService orderService) : INotificationHandler<ProductCreated>
    {
        private readonly IOrderService _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
        private readonly ILogger<ProductCreatedEventHandler> _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        
        public async Task Handle(ProductCreated notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Product Id {notification.ProductId} has been created. Place product in-take orders.");
#warning todo - for a new product, we want to test how much it sells so we won't order too much
            await _orderService.OrderAsync(notification.ProductId, orderType: domain.Common.Enums.OrderType.PilotOrder);

        }
    }
}
