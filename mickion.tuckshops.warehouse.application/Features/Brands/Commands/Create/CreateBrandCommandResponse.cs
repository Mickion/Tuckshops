using MediatR;
using mickion.tuckshops.shared.domain.Entities;
namespace mickion.tuckshops.warehouse.application.Features.Brands.Commands.Create;

public class CreateBrandCommandResponse: BaseResponse<BrandDto>, IRequest { }
