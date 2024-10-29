using FluentValidation;
using mickion.tuckshops.shared.application.Messages;
using mickion.tuckshops.warehouse.domain.Contracts.Repositories.Base;

namespace mickion.tuckshops.warehouse.application.Features.Product.Commands.Create
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateProductCommandValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(IUnitOfWork));

            RuleFor(x => x.Name).NotEmpty()
                .WithMessage(ValidationMessage.PRODUCT_NAME_REQUIRED);
            RuleFor(x => x)
                .MustAsync((x, cancellation) => ProductNotExist(x))
                .WithMessage(ValidationMessage.PRODUCT_ALREADY_EXISTS);

            RuleFor(x => x.ExpiryDateTime).NotEmpty()
                .WithMessage(ValidationMessage.PRODUCT_EXPIRY_DATETIME_REQUIRED);
            RuleFor(x => x.ExpiryDateTime)
                .Must((x, cancellation) => IsValidExpiryDate(x.ExpiryDateTime))
                .WithMessage(ValidationMessage.PRODUCT_EXPIRY_DATETIME_INVALID);

            RuleFor(x => x.UseByDateTime).NotEmpty()
                .WithMessage(ValidationMessage.PRODUCT_USEBY_DATETIME_REQUIRED);
            RuleFor(x => x.UseByDateTime)
                .Must((x, cancellation) => IsValidExpiryDate(x.UseByDateTime))
                .WithMessage(ValidationMessage.PRODUCT_USEBY_DATETIME_INVALID);

            RuleFor(x => x.Brand).NotNull()
                .WithMessage(ValidationMessage.PRODUCT_BRAND_REQUIRED);
            //RuleFor(x => x.Brand.Name)
            //    .MustAsync((x, cancellation) => BrandExist(x))
            //    .WithMessage(ValidationMessage.BRAND_NOTFOUND);

            RuleFor(x => x.Quantity).NotNull().WithMessage(ValidationMessage.PRODUCT_QUANTITY_REQUIRED);
            RuleFor(x => x.Measurements).NotNull().WithMessage(ValidationMessage.PRODUCT_MEASUREMENT_REQUIRED);
        }

        private async Task<bool> ProductNotExist(CreateProductCommand product) =>
            await _unitOfWork.ProductRepository.FindAsync(x => x.Name.Equals(product.Name, StringComparison.CurrentCultureIgnoreCase) 
            && x.Color.Equals(product.Color, StringComparison.CurrentCultureIgnoreCase)) == null;

        private static bool IsValidExpiryDate(DateTime expirydate) => expirydate > DateTime.UtcNow;

        //private async Task<bool> BrandExist(string name) =>
        //    await _unitOfWork.BrandRepository.FindAsync(brand => brand.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase)) != null;
    }
}
