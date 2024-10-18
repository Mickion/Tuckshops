using MediatR;

namespace mickion.tuckshops.warehouse.application.Features.Brands.Queries.Get;

public record GetBrandQuery: IRequest<BrandDto> { }
