
using System.ComponentModel.DataAnnotations;
using mickion.tuckshops.shared.domain.Contracts.Entities;

namespace mickion.tuckshops.warehouse.domain.Entities
{
    public class Product: IAuditableEntity
    {

        /// <summary>
        /// Gets or sets Code (Color+Bread)
        /// </summary>
        public string Code { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets Product Name
        /// </summary>
        [Required]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets Product Color
        /// </summary>
        [Required]
        public string Color { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets Product Description
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets product brand
        /// </summary>
        public Brand? Brand { get; set; }
                        
        /// <summary>
        /// A product can have many various sizes, 2litre, 3litre, 4litre
        /// </summary>
        public IEnumerable<Measurement>? Measurements { get; set; }

        #region IAuditableEntity
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid CreatedByUserId { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? ModifiedByUserId { get; set; }
        #endregion

        public Product()
        {
            this.Id = Guid.NewGuid();
        }

    }
}
