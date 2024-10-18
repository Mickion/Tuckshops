using MediatR;
using mickion.tuckshops.shared.domain.Entities;
namespace mickion.tuckshops.warehouse.application.Features.Brands.Queries.List;

public class ListBrandsQueryResponse: BaseResponse<IEnumerable<BrandDto>>, IRequest { }
