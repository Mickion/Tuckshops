namespace mickion.tuckshops.shared.application.Messages
{
    public class ErrorMessage
    {
        public ErrorMessage()
        {
            
        }
        public const string FAILURE_MSG = "Ooops, something went wrong!";

        public const string FAILED_TO_CREATE_BRAND = $"{FAILURE_MSG} Failed to create the specified brand.";
    }
}
