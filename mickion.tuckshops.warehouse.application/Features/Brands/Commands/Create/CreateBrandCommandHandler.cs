using FluentValidation;
using FluentValidation.Results;
using MediatR;
using mickion.tuckshops.shared.application.Helpers;
using mickion.tuckshops.shared.application.Messages;
using mickion.tuckshops.warehouse.domain.Contracts.Repositories.Base;
using mickion.tuckshops.warehouse.domain.Entities;
using Microsoft.Extensions.Logging;

namespace mickion.tuckshops.warehouse.application.Features.Brands.Commands.Create;

public class CreateBrandCommandHandler(ILogger<CreateBrandCommandHandler>? logger, IUnitOfWork? unitOfWork, IValidator<CreateBrandCommand> validator) : IRequestHandler<CreateBrandCommand, CreateBrandResponse>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(IUnitOfWork));
    private readonly ILogger<CreateBrandCommandHandler> _logger = logger ?? throw new ArgumentNullException(nameof(ILogger));
    private readonly IValidator<CreateBrandCommand> _validator = validator ?? throw new ArgumentNullException(nameof(IValidator));
    
    public async Task<CreateBrandResponse> Handle(CreateBrandCommand? request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return ResponseHelper<CreateBrandResponse, MapRequestToBrand(request)>.Map(MapRequestToBrand(request), validationResult.Errors);

            //return MapBrandToResponse(MapRequestToBrand(request), validationResult.Errors);                   

        var newbrand = _unitOfWork.BrandRepository.Add(MapRequestToBrand(request));
        await _unitOfWork.CommitChangesAsync(cancellationToken);

        return MapBrandToResponse(newbrand);
    }

    private static Brand MapRequestToBrand(CreateBrandCommand request) => new(){ Name = request.Name, Address = request.Address};

#warning extract return code into a generic
    private static CreateBrandResponse MapBrandToResponse(Brand brand, List<ValidationFailure>? validationFailures = null)
    {
        return new CreateBrandResponse
        {
            Success = validationFailures!.Count == 0,
            Message = validationFailures!.Count == 0 ? SuccessMessage.BRAND_CREATED_SUCCESSFULLY : ErrorMessage.FAILED_TO_CREATE_BRAND,
            Data = new(brand.Id, brand.Name, brand.Address, brand.CreatedDate, brand.CreatedByUserId, brand.ModifiedDate, brand.ModifiedByUserId)
        };
    }
}
