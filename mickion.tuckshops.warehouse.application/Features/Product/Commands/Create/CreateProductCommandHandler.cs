using FluentValidation;
using MediatR;
using mickion.tuckshops.shared.application.Helpers.Responses.Handlers;
using mickion.tuckshops.warehouse.application.Extensions;
using mickion.tuckshops.warehouse.application.Features.Product.Events;
using mickion.tuckshops.warehouse.domain.Contracts.Repositories.Base;
using mickion.tuckshops.warehouse.domain.Entities;
using Microsoft.Extensions.Logging;

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

        #region public methods
        public async Task<CreateProductCommandResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {            
            return await this.HandleAsync(request, cancellationToken).ConfigureAwait(false);
        }
        #endregion


        #region Private implementation details

        /// <summary>
        /// Creates a new Product
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>Details of the newly created Product</returns>
        private async Task<CreateProductCommandResponse> HandleAsync(CreateProductCommand request, CancellationToken cancellationToken)
        {
            // Validate
            domain.Entities.Product? response = new();

            ArgumentNullException.ThrowIfNull(request);
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (validationResult.IsValid is not true)
                return ResponseHelper<CreateProductCommandResponse, ProductDto>.Error(response!.ToProductDto(), validationResult.Errors);

            // Process
            response.Name = request.Name;
            response.Color = request.Color;
            response.Barcode = request.Barcode;
            response.ExpiryDateTime = request.ExpiryDateTime;
            response.UseByDateTime = request.UseByDateTime;
            response.Brand = await HandleProductBrandAsync(request.ProductBrandName, request.ProductBrandAddress!, cancellationToken).ConfigureAwait(false);
            response.Measurements = await HandleProductMeasurementAsync(request.Measurements, cancellationToken).ConfigureAwait(false);
            response.Quantity = await HandleProductQuantityAsync(response.Id, request.StockOnHand, request.StockOnOrder, cancellationToken).ConfigureAwait(false);

            response = await _unitOfWork.ProductRepository.AddAsync(response, cancellationToken).ConfigureAwait(false);          
            await _unitOfWork.CommitChangesAsync(cancellationToken).ConfigureAwait(false);

            // Publish Product created
            await _publisher.Publish(new ProductCreated(response.Id), cancellationToken);

            // Respond
            return ResponseHelper<CreateProductCommandResponse, ProductDto>.Success(response!.ToProductDto());
        }

        /// <summary>
        /// Creates new product brand if it doesn't exists
        /// </summary>
        /// <param name="productBrand"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>Details of the newly created Product Brand</returns>
        private async Task<Brand> HandleProductBrandAsync(string brandName, string brandAddress, CancellationToken cancellationToken)
        {            
            var brand = await _unitOfWork.BrandRepository.FindAsync(x => x.Name.ToLower() == brandName.ToLower());

            if (brand is null)
                // If brand dont exists, create one
                brand = await _unitOfWork.BrandRepository.AddAsync(new() { Name = brandName, Address = brandAddress }, cancellationToken);
            
            return brand;
        }

        /// <summary>
        /// Creates new product measurements if none exists.
        /// </summary>
        /// <param name="productMeasurement"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>Details of the newly created Product Measurement</returns>
        private async Task<IEnumerable<Measurement>> HandleProductMeasurementAsync(IEnumerable<MeasurementDto> productMeasurement, CancellationToken cancellationToken)
        {
            List<Measurement> measurements = [];

            foreach (var measurementItem in productMeasurement) {
                var measurement =
                    await _unitOfWork.MeasurementRepository.FindAsync(x => x.Size == measurementItem.Size && x.Type.ToLower() == measurementItem.Type.ToLower(), cancellationToken);

                if (measurement is null)
                    // If measurement match dont exists, create one
                    measurement = await _unitOfWork.MeasurementRepository.AddAsync(new() { Size = measurementItem.Size, Type = measurementItem.Type }, cancellationToken);

                measurements.Add(measurement);
            }

            return measurements;
        }

        /// <summary>
        /// Creates new product quantity if none exists.
        /// </summary>
        /// <param name="productQty"></param>
        /// <param name="productId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>Details of the newly created Product Quantity</returns>
        private async Task<Quantity> HandleProductQuantityAsync(Guid productId, int stockOnHand, int stockOnOrder, CancellationToken cancellationToken)
        {
            var productQuantity =
                await _unitOfWork.QuantityRepository.FindAsync(x => x.ProductId == productId, cancellationToken);

            if (productQuantity is null)
                // If measurement match dont exists, create one
                productQuantity = await _unitOfWork.QuantityRepository.AddAsync(new() { ProductId= productId, StockOnHand = stockOnHand, StockOnOrder = stockOnOrder}, cancellationToken);

            return productQuantity;
        }
        #endregion
    }
}
