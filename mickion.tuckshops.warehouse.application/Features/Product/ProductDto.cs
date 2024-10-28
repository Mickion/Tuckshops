using mickion.tuckshops.warehouse.domain.Entities;

public record ProductDto(
    Guid? Id,
    string Name,
    string Color,
    string Barcode,
    DateTime ExpiryDateTime,
    DateTime UseByDateTime,
    BrandDto Brand,
    Measurement Measurements,
    Quantity Quantity,
    DateTime? CreatedDate,
    Guid? CreatedByUserId,
    DateTime? ModifiedDate,
    Guid? ModifiedByUserId
);

#warning Refactor what gets return