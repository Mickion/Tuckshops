using MediatR;

namespace mickion.tuckshops.warehouse.application.Features.Product.Commands.Create;

public record CreateProductCommand(
    string Name,
    string Color,
    string Description,
    string ProductBrandName,
    string? ProductBrandAddress,    
    IEnumerable<MeasurementDto> Measurements
) : IRequest<CreateProductCommandResponse>;
