namespace mickion.tuckshops.shared.application.Messages
{
    public static class ValidationMessage
    {
        #region Brand feature messages
        public const string BRAND_NAME_REQUIRED = "Brand Name is a required field.";
        public const string BRAND_ADDRESS_REQUIRED = "Brand Address is a required field.";
        public const string BRAND_ALREADY_EXISTS = "A Brand with the same name already exist.";
        public const string BRAND_NOTFOUND = "Brand not found";
        public const string BRANDS_NOTFOUND = "Brands not found";       
        #endregion

        #region Product feature messages
        public const string PRODUCT_NAME_REQUIRED = "Product Name is a required field.";
#warning Expiry date should be on stock, not product level??
        public const string PRODUCT_EXPIRY_DATETIME_REQUIRED = "Expiry Date is a required field.";
        public const string PRODUCT_EXPIRY_DATETIME_INVALID = "Expiry Date is invalid.";
        public const string PRODUCT_USEBY_DATETIME_REQUIRED = "UseBy Date is a required field.";
        public const string PRODUCT_USEBY_DATETIME_INVALID = "UseBy Date is invalid.";
        public const string PRODUCT_ALREADY_EXISTS = "A Product with the same name already exist.";
        public const string PRODUCT_NOTFOUND = "Product not found.";
        public const string PRODUCTS_NOTFOUND = "Products not found.";
        public const string PRODUCT_BRAND_REQUIRED = "Product brand is required.";
        public const string PRODUCT_MEASUREMENT_REQUIRED = "Product Measurement is required.";
        public const string PRODUCT_QUANTITY_REQUIRED = "Product Quantity is required.";

        #endregion
    }
}
