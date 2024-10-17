using FluentValidation;
using mickion.tuckshops.shared.application.Messages;
using mickion.tuckshops.warehouse.domain.Contracts.Repositories.Base;

namespace mickion.tuckshops.warehouse.application.Features.Brands.Commands.Create
{
    public class CreateBrandValidator: AbstractValidator<CreateBrandCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateBrandValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(IUnitOfWork));

            RuleFor(x => x.Name).NotEmpty().WithMessage(ValidationMessage.BRAND_NAME_REQUIRED);
            RuleFor(x => x.Name)
                .MustAsync((x, cancellation) => BrandDoesNotExist(x))
                .WithMessage("An event with the same name and date already exists.");

            RuleFor(x => x.Address).NotEmpty().WithMessage(ValidationMessage.BRAND_ADDRESS_REQUIRED);
        }

        private async Task<bool> BrandDoesNotExist(string name)
        {
            var exists = (await _unitOfWork.BrandRepository.FindAsync(x => x.Name == name) == null);
            return (await _unitOfWork.BrandRepository.FindAsync(x => x.Name == name) == null);
        }
    }
}
