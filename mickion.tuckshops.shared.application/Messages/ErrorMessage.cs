namespace mickion.tuckshops.shared.application.Messages
{
    public static class ErrorMessage
    {
        public const string FAILURE_MSG = "Ooops, something went wrong!";
        
        #region Brand feature messages
        public const string FAILED_TO_CREATE_BRAND = $"{FAILURE_MSG} Failed to create the specified brand.";
        #endregion

    }
}
