using FluentValidation.Results;
using mickion.tuckshops.shared.application.Messages;
using mickion.tuckshops.shared.domain.Entities;

namespace mickion.tuckshops.shared.application.Helpers
{
    public static class ResponseHelper<TResponse, TResponseData> where TResponse : BaseResponse<TResponseData>, new()
    {
        public static TResponse Map(TResponseData responseData, List<ValidationFailure>? validationFailures = null)
        {
            return new TResponse
            {
                Success = validationFailures!.Count == 0,
                Message = validationFailures!.Count == 0 ? SuccessMessage.BRAND_CREATED_SUCCESSFULLY : ErrorMessage.FAILED_TO_CREATE_BRAND,
                ValidationErrors = validationFailures!.Count > 0 ? [.. validationFailures!] : null,
                Data = responseData
            };
        }
    }
}
