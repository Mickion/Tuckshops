namespace mickion.tuckshops.shared.domain.Contracts.Entities;

public interface IAuditableEntity : IEntity
{    
    public DateTime CreatedDate { get; set; }

    public Guid CreatedByUserId { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public Guid? ModifiedByUserId { get; set; }
}
