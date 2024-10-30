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
            response.Description = request.Description;
            response.Code = $"{request.Color}_{request.Name}";


            response.Brand = new();
            response.Brand = await GetOrCreateProductBrandAsync(request.ProductBrandName, request.ProductBrandAddress!, cancellationToken).ConfigureAwait(false);
            response.Measurements = await GetOrCreateProductMeasurementAsync(response, request.Measurements, response.Id, cancellationToken).ConfigureAwait(false);
            //response.Quantity = await HandleProductQuantityAsync(response.Id, request.StockOnHand, request.StockOnOrder, cancellationToken).ConfigureAwait(false);

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
        /// <param name="brandName"></param>
        /// <param name="brandAddress"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        private async Task<Brand> GetOrCreateProductBrandAsync(string brandName, string brandAddress, CancellationToken cancellationToken)
        {            
            var brand = 
                await _unitOfWork.BrandRepository.FindAsync(x => x.Name.ToLower() == brandName.ToLower());
                        
            if (brand is null)
                // If brand dont exists, create one
                brand = await _unitOfWork.BrandRepository.AddAsync(new() { Name = brandName, Address = brandAddress }, cancellationToken);            
        
            return brand;
        }

        /// <summary>
        /// Creates new product measurements if none exists.
        /// </summary>
        /// <param name="product"></param>
        /// <param name="productMeasurement"></param>
        /// <param name="productId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        private async Task<IEnumerable<Measurement>> GetOrCreateProductMeasurementAsync(domain.Entities.Product product, IEnumerable<MeasurementDto> productMeasurement,Guid productId, CancellationToken cancellationToken)
        {
            List<Measurement> measurements = [];

            // Foreach measurement, create linked qty & prices
            foreach (var measurementItem in productMeasurement) {

                var measurement =
                    await _unitOfWork.MeasurementRepository.FindAsync(x => x.Size == measurementItem.Size && x.Type.ToLower() == measurementItem.Type.ToLower(), cancellationToken);

                // If measurement dont exists (null coalescing operator), create one
                measurement ??= await _unitOfWork.MeasurementRepository.AddAsync(new() { Size = measurementItem.Size, Type = measurementItem.Type }, cancellationToken);
                measurements.Add(measurement);

                // For each measurement, create linked quantity and prices
                var measurementQty = await CreateProductQuantityAsync(product, measurement, measurementItem.StockOnHand, measurementItem.StockOnOrder, cancellationToken);
                var measurementPrice = await CreateProductPriceAsync(product, measurement, measurementItem.BuyingPrice, measurementItem.SellingPrice, cancellationToken);
            }

            return measurements;
        }


        /// <summary>
        /// Creates new product quantity if none exists.
        /// </summary>
        /// <param name="product"></param>
        /// <param name="measurement"></param>
        /// <param name="stockOnHand"></param>
        /// <param name="stockOnOrder"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        private async Task<Quantity> CreateProductQuantityAsync(domain.Entities.Product product, Measurement measurement, int stockOnHand, int stockOnOrder, CancellationToken cancellationToken)
        {
            var productQuantity =
                await _unitOfWork.QuantityRepository.FindAsync(x => x.Product!.Id == product.Id && x.Measurement!.Id == measurement.Id, cancellationToken);

            return (productQuantity is not null) ? productQuantity :  // If measurement match dont exists, create one
                await _unitOfWork.QuantityRepository.AddAsync(new() { StockOnHand = stockOnHand, StockOnOrder = stockOnOrder, Product = product, Measurement = measurement }, cancellationToken);
        }


        /// <summary>
        /// Creates new product price if none exists.
        /// </summary>
        /// <param name="product"></param>
        /// <param name="measurement"></param>
        /// <param name="buyingPrice"></param>
        /// <param name="sellingPrice"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        private async Task<Price> CreateProductPriceAsync(domain.Entities.Product product, Measurement measurement, decimal buyingPrice, decimal sellingPrice, CancellationToken cancellationToken)
        {
            var productPrice =
                await _unitOfWork.PriceRepository.FindAsync(x => x.Product!.Id == product.Id && x.Measurement!.Id == measurement.Id, cancellationToken);

            return (productPrice is not null) ? productPrice : // If measurement match dont exists, create one
                await _unitOfWork.PriceRepository.AddAsync(new() { BuyingPrice = buyingPrice, SellingPrice = sellingPrice, Product = product, Measurement = measurement }, cancellationToken);
        }
        #endregion
    }
}
