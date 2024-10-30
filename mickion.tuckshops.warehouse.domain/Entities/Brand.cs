using mickion.tuckshops.shared.domain.Contracts.Entities;
using mickion.tuckshops.shared.domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace mickion.tuckshops.warehouse.domain.Entities
{
    public class Brand: IEntity, IAuditableEntity
    {
        /// <summary>
        /// Gets or sets brand name
        /// </summary>
        [Required]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets brand Address
        /// </summary>
        public string Address { get; set; } = string.Empty;


        /// <summary>
        /// A brand can have many products, i.e. Apple has iPhones, iPads etc..
        /// </summary>
        public IEnumerable<Product>? Products { get; set; }

        #region IAuditableEntity
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid CreatedByUserId { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? ModifiedByUserId { get; set; }
        #endregion

    }
#warning Extract to Address Entity or Brand Details
}
