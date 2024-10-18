using FluentValidation.Results;

namespace mickion.tuckshops.shared.domain.Entities
{
    public class BaseResponse<TEntityDto>
    {
        public bool IsSuccess { get; set; } = true;

        public List<ValidationFailure>? ErrorMessages { get; set; } = null;

        public TEntityDto? Entity { get; set; } = default;
    }
}
