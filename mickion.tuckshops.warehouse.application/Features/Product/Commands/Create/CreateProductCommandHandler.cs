using FluentValidation;
using MediatR;
using mickion.tuckshops.shared.application.Helpers.Responses.Handlers;
using mickion.tuckshops.warehouse.application.Features.Brands.Commands.Create;
using mickion.tuckshops.warehouse.application.Helpers;
using mickion.tuckshops.warehouse.domain.Contracts.Repositories.Base;
using mickion.tuckshops.warehouse.domain.Entities;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;

namespace mickion.tuckshops.warehouse.application.Features.Product.Commands.Create
{
    public class CreateProductCommandHandler(
        ILogger<CreateProductCommandHandler>? logger, IUnitOfWork? unitOfWork, IValidator<CreateProductCommand> validator,
    IPublisher publisher) : IRequestHandler<CreateProductCommand, CreateProductCommandResponse>
    {
        private readonly IPublisher _publisher = publisher ?? throw new ArgumentNullException(nameof(publisher));
        private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(IUnitOfWork));
        private readonly ILogger<CreateProductCommandHandler> _logger = logger ?? throw new ArgumentNullException(nameof(ILogger));
        private readonly IValidator<CreateProductCommand> _validator = validator ?? throw new ArgumentNullException(nameof(IValidator));

        public async Task<CreateProductCommandResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);
            domain.Entities.Product? response = null;

            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (validationResult.IsValid is not true)
                return ResponseHelper<CreateProductCommandResponse, ProductDto>.Error(MapHelper.ProductToDto(response)!, validationResult.Errors);

            // If brand dont exists, create one else link to existing brand. Same as Measurements etc..
            var brand = 
                await _unitOfWork.BrandRepository.FindAsync(x => x.Name.Equals(request.Brand.Name,StringComparison.InvariantCultureIgnoreCase));
            if(brand is null)
            {                

                await _unitOfWork.BrandRepository.AddAsync(MapHelper.DtoToBrand(request.Brand), cancellationToken);
            }

            var measurements = await _unitOfWork.MeasurementRepository.FindAsync(x => x.Equals(request.Measurements));
            if (measurements is null) {
                await _unitOfWork.MeasurementRepository.AddAsync(request.Measurements, cancellationToken);
            }

            return ResponseHelper<CreateProductCommandResponse, ProductDto>.Success(MapHelper.ProductToDto(response)!);
        }
    }
}
