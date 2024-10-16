
using MediatR;
using FluentValidation;
using mickion.tuckshops.shared.application.Helpers;
using mickion.tuckshops.warehouse.domain.Contracts.Repositories.Base;
using mickion.tuckshops.warehouse.domain.Entities;
using Microsoft.Extensions.Logging;

namespace mickion.tuckshops.warehouse.application.Features.Brands.Commands.Create;

public class CreateBrandCommandHandler(ILogger<CreateBrandCommandHandler>? logger, IUnitOfWork? unitOfWork, IValidator<CreateBrandCommand> validator) : IRequestHandler<CreateBrandCommand, CreateBrandResponse>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(IUnitOfWork));
    private readonly ILogger<CreateBrandCommandHandler> _logger = logger ?? throw new ArgumentNullException(nameof(ILogger));
    private readonly IValidator<CreateBrandCommand> _validator = validator ?? throw new ArgumentNullException(nameof(IValidator));

    #region public methods
    public async Task<CreateBrandResponse> Handle(CreateBrandCommand? request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        Brand newbrand = new();        
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (validationResult.IsValid is not true)        
            return HandlerResponseHelper<CreateBrandResponse, CreateBrandResponseDto>.Map(MapBrandToDto(newbrand), validationResult.Errors);
        
            
        newbrand = _unitOfWork.BrandRepository.Add(MapDtoToBrand(request));
        await _unitOfWork.CommitChangesAsync(cancellationToken);

        return HandlerResponseHelper<CreateBrandResponse, CreateBrandResponseDto>.Map(MapBrandToDto(newbrand), validationResult.Errors);
    }

    #endregion

    #region private methods
    private static Brand MapDtoToBrand(CreateBrandCommand request) => new(){ Name = request.Name, Address = request.Address};

    private static CreateBrandResponseDto MapBrandToDto(Brand brand) =>
        new(brand.Id, brand.Name, brand.Address, brand.CreatedDate, brand.CreatedByUserId, brand.ModifiedDate, brand.ModifiedByUserId);

    #endregion
}
