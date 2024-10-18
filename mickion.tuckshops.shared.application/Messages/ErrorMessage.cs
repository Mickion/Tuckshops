namespace mickion.tuckshops.shared.application.Messages
{
    public static class ErrorMessage
    {
        public const string FAILURE_MSG = "Ooops, something went wrong!";
        public const string FAILURE_CODE = "500";
                
        #region Brand feature messages
        public const string FAILED_TO_CREATE_BRAND = $"{FAILURE_MSG} Failed to create the specified brand.";
        public const string FAILED_TO_RETRIEVED_BRAND = $"{FAILURE_MSG}. There are no brands currently on the database.";
        #endregion

    }
}
