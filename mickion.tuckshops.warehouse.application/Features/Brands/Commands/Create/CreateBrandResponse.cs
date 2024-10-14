using MediatR;

namespace mickion.tuckshops.warehouse.application.Features.Brands.Commands.Create;

public record CreateBrandResponse(Guid Id, string Name, string Address, DateTime CreatedDate, Guid CreatedByUserId, DateTime ModifiedDate, Guid ModifiedByUserId): IRequest;
