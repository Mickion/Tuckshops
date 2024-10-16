namespace mickion.tuckshops.shared.domain.Entities
{
    public class EntityAudit
    {
        public DateTime CreatedDate { get; set; }

        public Guid CreatedByUserId { get; set; }

        public DateTime? ModifiedDate { get; set; } = null;

        public Guid? ModifiedByUserId { get;  set; } = null;
    }
}
