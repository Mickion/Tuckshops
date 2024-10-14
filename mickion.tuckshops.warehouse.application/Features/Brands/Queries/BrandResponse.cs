namespace mickion.tuckshops.warehouse.application.Features.Brands.Queries;

public record BrandResponse (Guid Id, string Name, string Address, DateTime CreatedDate, Guid CreatedByUserId, DateTime ModifiedDate, Guid ModifiedByUserId);
