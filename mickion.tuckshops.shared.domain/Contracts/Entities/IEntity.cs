namespace mickion.tuckshops.shared.domain.Contracts.Entities;

public interface IEntity
{
    public Guid Id { get; set; }

    public DateTime CreatedDate { get; set; }

    public Guid CreatedByUserId { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public Guid? ModifiedByUserId { get; set; }
}
