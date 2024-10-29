using MediatR;
using mickion.tuckshops.shared.domain.Entities;

namespace mickion.tuckshops.warehouse.application.Features.Product.Queries.List;

public class ListProductsQueryResponse: BaseResponse<IEnumerable<ProductDto>>, IRequest { }

