using FluentValidation.Results;

namespace mickion.tuckshops.shared.domain.Entities
{
    public class BaseResponse<TResponseDto>
    {
        public bool IsSuccess { get; set; } = true;

        public List<ValidationFailure>? ErrorMessages { get; set; } = null;

        public TResponseDto? Data { get; set; } = default;
    }
}
