using MediatR;

namespace mickion.tuckshops.warehouse.application.Features.Product.Events;

#warning todo - just testing for now
internal record ProductCreated(Guid ProductId) : INotification;
