using System.ComponentModel.DataAnnotations;

namespace mickion.tuckshops.warehouse.domain.Entities.Base
{
    public class BaseEntity
    {
        /// <summary>
        /// Gets or sets Unique identifier 
        /// </summary>
        [Required]
        public Guid Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public User CreatedBy { get; set; } = new User();

        public DateTime ModifiedDate { get; set; }

        public User ModifiedBy { get; set; } = new User();
    }
}
