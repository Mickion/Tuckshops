public record BrandDto(Guid? Id,
                                  string Name,
                                  string Address,
                                  DateTime? CreatedDate,
                                  Guid? CreatedByUserId,
                                  DateTime? ModifiedDate,
                                  Guid? ModifiedByUserId);
