namespace mickion.tuckshops.warehouse.application.Features.Product
{
    public record MeasurementDto(
        double Size,
        string Type,
        int StockOnHand,
        int StockOnOrder,
        decimal BuyingPrice,
        decimal SellingPrice
    ) { }
}
