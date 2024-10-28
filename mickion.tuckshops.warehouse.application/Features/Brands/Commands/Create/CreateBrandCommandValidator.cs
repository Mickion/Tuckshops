using FluentValidation;
using mickion.tuckshops.shared.application.Messages;
using mickion.tuckshops.warehouse.domain.Contracts.Repositories.Base;

namespace mickion.tuckshops.warehouse.application.Features.Brands.Commands.Create
{
    public class CreateBrandCommandValidator: AbstractValidator<CreateBrandCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateBrandCommandValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(IUnitOfWork));

            RuleFor(x => x.Name).NotEmpty().WithMessage(ValidationMessage.BRAND_NAME_REQUIRED);
            RuleFor(x => x.Name)
                .MustAsync((x, cancellation) => BrandNotExist(x))
                .WithMessage(ValidationMessage.BRAND_ALREADY_EXISTS);

            RuleFor(x => x.Address).NotEmpty().WithMessage(ValidationMessage.BRAND_ADDRESS_REQUIRED);
        }

        private async Task<bool> BrandNotExist(string name) => 
            await _unitOfWork.BrandRepository.FindAsync(brand => brand.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase)) == null;
       
    }
}
