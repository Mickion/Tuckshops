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

            RuleFor(x => x.ProductBrandName).NotEmpty()
                .WithMessage(ValidationMessage.PRODUCT_BRAND_REQUIRED);
            
            RuleFor(x => x.Measurements).NotNull().WithMessage(ValidationMessage.PRODUCT_MEASUREMENT_REQUIRED);
        }

        private async Task<bool> ProductNotExist(CreateProductCommand product) =>
            await _unitOfWork.ProductRepository.FindAsync(x => x.Name.ToLower() == product.Name.ToLower() && x.Color.ToLower() ==product.Color.ToLower()) == null;
        
    }
}
