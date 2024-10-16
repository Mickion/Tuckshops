using System.ComponentModel.DataAnnotations;

namespace mickion.tuckshops.shared.domain.Entities
{
    public class BaseEntity: EntityAudit
    {
        /// <summary>
        /// Gets or sets Unique identifier 
        /// </summary>
        [Required]
        public Guid Id { get; private set; } = Guid.Empty;

        public BaseEntity()
        {
            Id = new Guid();
        }
    }
}
