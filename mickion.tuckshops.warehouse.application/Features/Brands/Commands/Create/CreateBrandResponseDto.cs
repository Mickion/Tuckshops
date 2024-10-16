using mickion.tuckshops.warehouse.domain.Entities;

public record CreateBrandResponseDto(Guid? Id,
                                  string Name,
                                  string Address,
                                  DateTime? CreatedDate,
                                  Guid? CreatedByUserId,
                                  DateTime? ModifiedDate,
                                  Guid? ModifiedByUserId);
