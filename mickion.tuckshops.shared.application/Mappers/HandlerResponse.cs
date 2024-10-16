using FluentValidation.Results;
using mickion.tuckshops.shared.application.Messages;
using mickion.tuckshops.shared.domain.Entities;

namespace mickion.tuckshops.shared.application.Mappers
{
    public static class HandlerResponse <TEntity> where TEntity : BaseResponse<TEntity>, new()
    {
        public static TEntity Map(TEntity entity, List<ValidationFailure>? validationFailures = null) 
        {
            return new TEntity
            {
                Success = validationFailures!.Count == 0,
                Message = validationFailures!.Count == 0 ? SuccessMessage.BRAND_CREATED_SUCCESSFULLY : ErrorMessage.FAILED_TO_CREATE_BRAND,
                ValidationErrors = validationFailures!.Count > 0 ? [.. validationFailures!] : null,
                Data = entity
            };
        }
    }
}
