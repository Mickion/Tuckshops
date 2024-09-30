using System.ComponentModel.DataAnnotations;

namespace mickion.tuckshops.shared.domain.Entities
{
    public class BaseEntity
    {
        /// <summary>
        /// Gets or sets Unique identifier 
        /// </summary>
        [Required]
        public Guid Id { get; private set; }

        public DateTime CreatedDate { get; private set; }

        public Guid CreatedByUserId { get; private set; }

        public DateTime ModifiedDate { get; private set; }

        public Guid ModifiedByUserId { get; private set; }

        public BaseEntity()
        {
            this.Id = Guid.NewGuid();
            //TODO: If action is create, set CreatedDate else ModifiedDate
            this.CreatedDate = DateTime.Now;
            this.ModifiedDate = DateTime.Now;
            this.CreatedByUserId = GetCurrentUserId();
            this.ModifiedByUserId = GetCurrentUserId();
        }

        private static Guid GetCurrentUserId()
        {
            //TODO: Get the current user ID
            return Guid.NewGuid();
        }
    }
}
