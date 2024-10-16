using MediatR;
using mickion.tuckshops.shared.application.Exceptions;
using mickion.tuckshops.warehouse.domain.Contracts.Repositories.Base;
using mickion.tuckshops.warehouse.domain.Entities;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Xml.Linq;

namespace mickion.tuckshops.warehouse.application.Features.Brands.Commands.Create;

public class CreateBrandCommandHandler(ILogger<CreateBrandCommandHandler>? logger, IUnitOfWork? unitOfWork) : IRequestHandler<CreateBrandCommand, CreateBrandResponse>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(IUnitOfWork));
    private readonly ILogger<CreateBrandCommandHandler> _logger = logger ?? throw new ArgumentNullException(nameof(ILogger));
    
    public async Task<CreateBrandResponse> Handle(CreateBrandCommand? request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        if (string.IsNullOrWhiteSpace(request.Name)) throw new FieldRequiredException(nameof(request.Name));
        if (string.IsNullOrWhiteSpace(request.Address)) throw new FieldRequiredException(nameof(request.Address));

        var newbrand = _unitOfWork.BrandRepository.Add(MapRequestToBrand(request));
        await _unitOfWork.CommitChangesAsync(cancellationToken);

        return MapBrandToResponse(newbrand);
    }

    private static Brand MapRequestToBrand(CreateBrandCommand request) => new(){ Name = request.Name, Address = request.Address};
    
    private static CreateBrandResponse MapBrandToResponse(Brand brand) => new(brand.Id, brand.Name, brand.Address, brand.CreatedDate, brand.CreatedByUserId, brand.ModifiedDate, brand.ModifiedByUserId);
    
}
