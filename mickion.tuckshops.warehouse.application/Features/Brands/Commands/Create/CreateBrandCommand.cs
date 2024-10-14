using MediatR;

namespace mickion.tuckshops.warehouse.application.Features.Brands.Commands.Create;

public record CreateBrandCommand (string Name, string Address): IRequest<CreateBrandResponse>;
