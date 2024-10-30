using mickion.tuckshops.warehouse.domain.Entities;

public record ProductDto(
    Guid? Id,
    string Name,
    string Color,
    string Barcode,
    BrandDto Brand,
    IEnumerable<Measurement> Measurements,
    //Quantity Quantity,
    DateTime? CreatedDate,
    Guid? CreatedByUserId,
    DateTime? ModifiedDate,
    Guid? ModifiedByUserId
);

#warning Refactor what gets return