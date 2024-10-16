using FluentValidation.Results;
using mickion.tuckshops.shared.domain.Entities;

namespace mickion.tuckshops.shared.application.Helpers
{
    public static class HandlerResponseHelper<THandlerResponse, TDataDto> where THandlerResponse : BaseResponse<TDataDto>, new()
    {
        public static THandlerResponse Map(TDataDto responseData, List<ValidationFailure>? validationFailures = null)
        {
            return new THandlerResponse
            {
                IsSuccess = validationFailures!.Count == 0,
                ErrorMessages = validationFailures!.Count > 0 ? [.. validationFailures!] : null,                
                Data = responseData
            };
        }
    }
}
