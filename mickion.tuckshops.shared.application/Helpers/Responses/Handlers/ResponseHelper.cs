using FluentValidation.Results;
using FluentValidation;
using mickion.tuckshops.shared.domain.Entities;
using mickion.tuckshops.shared.application.Messages;

#warning refactor exception handling into a Middleware
#warning Abstract shared modules into Interfaces to allow exchanging implementation details without affecting the others
namespace mickion.tuckshops.shared.application.Helpers.Responses.Handlers
{
    public class ResponseHelper<THandlerResponse, TEntityDto> where THandlerResponse : BaseResponse<TEntityDto>, new()
    {
        public static THandlerResponse Error(TEntityDto responseDto, string errorMessage) =>
            new THandlerResponse()
            {
                IsSuccess = false,
                ErrorMessages = [ new()
                {
                    Severity = Severity.Error,
                    ErrorMessage = errorMessage,
                    ErrorCode = ErrorMessage.FAILURE_CODE,
                    //PropertyName = typeof(TEntityDto).ToString()                    
                }],
                Entity = responseDto,
            };
       

        public static THandlerResponse Error(TEntityDto responseDto, List<ValidationFailure>? validationFailures) =>
             new THandlerResponse()
             {
                IsSuccess = false,
                ErrorMessages = [.. validationFailures!],
                Entity = responseDto,
            };

        public static THandlerResponse Success(TEntityDto responseDto) =>
             new THandlerResponse()
             {
                 IsSuccess = true,
                 ErrorMessages = null,
                 Entity = responseDto,
             };
    }
}
