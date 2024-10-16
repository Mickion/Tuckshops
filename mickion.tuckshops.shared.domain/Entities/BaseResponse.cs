using FluentValidation.Results;

namespace mickion.tuckshops.shared.domain.Entities
{
    public class BaseResponse<TEntity>
    {
        public bool Success { get; set; } = true;

        public string Message { get; set; } = string.Empty;

        public List<ValidationFailure>? ValidationErrors { get; set; } = null;

        public TEntity? Data { get; set; } = default;
    }
}
