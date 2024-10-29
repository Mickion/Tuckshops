
using MediatR;
using FluentValidation;
using Microsoft.Extensions.Logging;
using mickion.tuckshops.warehouse.domain.Entities;
using mickion.tuckshops.warehouse.domain.Contracts.Repositories.Base;
using mickion.tuckshops.shared.application.Helpers.Responses.Handlers;
using mickion.tuckshops.warehouse.application.Extensions;
using mickion.tuckshops.shared.application.Messages;


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
        return await HandleAsync(request, cancellationToken).ConfigureAwait(false);
        // ConfigureAwait(false) may improve performance if there are not many worker threads available and if the thread that it would need to wait for is constantly busy.
    }
    #endregion

    #region Private implementation
    private async Task<CreateBrandCommandResponse> HandleAsync(CreateBrandCommand? request, CancellationToken cancellationToken)
    {
        Brand? response = null;

        // Validate
        ArgumentNullException.ThrowIfNull(request);
        var validationResult = await _validator.ValidateAsync(request!, cancellationToken);
        if (validationResult.IsValid is not true)
            return ResponseHelper<CreateBrandCommandResponse, BrandDto>.Error(response!.ToBrandDto(), validationResult.Errors);

        // Process
        response = await _unitOfWork.BrandRepository.AddAsync(new Brand { Name = request!.Name, Address = request.Address }, cancellationToken);
        if (response is null)
            return ResponseHelper<CreateBrandCommandResponse, BrandDto>.Error(response!.ToBrandDto(), ErrorMessage.FAILED_TO_CREATE_BRAND);

        await _unitOfWork.CommitChangesAsync(cancellationToken);

        // Respond
        return ResponseHelper<CreateBrandCommandResponse, BrandDto>.Success(response.ToBrandDto());
    }
    #endregion

}
