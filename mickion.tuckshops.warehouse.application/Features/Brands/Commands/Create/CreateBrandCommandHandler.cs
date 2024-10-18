
using MediatR;
using FluentValidation;
using Microsoft.Extensions.Logging;
using mickion.tuckshops.warehouse.domain.Entities;
using mickion.tuckshops.warehouse.application.Helpers;
using mickion.tuckshops.warehouse.domain.Contracts.Repositories.Base;
using mickion.tuckshops.warehouse.application.Features.Product.Events;
using mickion.tuckshops.shared.application.Helpers.Responses.Handlers;


namespace mickion.tuckshops.warehouse.application.Features.Brands.Commands.Create;

public class CreateBrandCommandHandler(
    ILogger<CreateBrandCommandHandler>? logger, 
    IUnitOfWork? unitOfWork, IValidator<CreateBrandCommand> validator,
    IPublisher publisher) : IRequestHandler<CreateBrandCommand, CreateBrandCommandResponse>
{
    private readonly IPublisher _publisher = publisher ?? throw new ArgumentNullException(nameof(publisher));
    private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(IUnitOfWork));
    private readonly ILogger<CreateBrandCommandHandler> _logger = logger ?? throw new ArgumentNullException(nameof(ILogger));
    private readonly IValidator<CreateBrandCommand> _validator = validator ?? throw new ArgumentNullException(nameof(IValidator));

    #region public methods
    public async Task<CreateBrandCommandResponse> Handle(CreateBrandCommand? request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        Brand? response = null;
        
        try
        {            
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (validationResult.IsValid is not true)
                return ResponseHelper<CreateBrandCommandResponse, BrandDto>.Error(MapHelper.BrandToDto(response)!, validationResult.Errors);
            
            try
            {                
                //if event publishing fails, rollback all the changes via unit of work.
                response = _unitOfWork.BrandRepository.Add(MapHelper.DtoToBrand(request));                
                await _publisher.Publish(new ProductCreated(response.Id), cancellationToken);
                await _unitOfWork.CommitChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {                
                _logger.LogCritical("UnitOfWork or Publisher failed: "+ ex.Message, ex);
                return ResponseHelper<CreateBrandCommandResponse, BrandDto>.Error(MapHelper.BrandToDto(response)!, ex.Message);
            }
        }
        catch (Exception ex)
        {            
            _logger.LogCritical("Fluent Validator failed: " + ex.Message, ex);
            return ResponseHelper<CreateBrandCommandResponse, BrandDto>.Error(MapHelper.BrandToDto(response)!, ex.Message);
        }

        return ResponseHelper<CreateBrandCommandResponse, BrandDto>.Success(MapHelper.BrandToDto(response)!);
    }

    #endregion


}
