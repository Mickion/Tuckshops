using MediatR;
using mickion.tuckshops.shared.domain.Entities;

namespace mickion.tuckshops.warehouse.application.Features.Product.Commands.Create;

public class CreateProductCommandResponse : BaseResponse<ProductDto>, IRequest { }
