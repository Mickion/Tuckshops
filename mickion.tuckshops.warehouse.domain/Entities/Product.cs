using mickion.tuckshops.shared.domain.Contracts.Entities;
using mickion.tuckshops.shared.domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace mickion.tuckshops.warehouse.domain.Entities
{
    public class Product: BaseEntity, IEntity
    {
        [Required]
        public string Code { get; set; } = string.Empty; //TODO: Generate unique code

        [Required]
        public string Name { get; set; } = string.Empty; // i.e. Bread

        public string Color { get; set; } = string.Empty; // i.e. White bread (optional)

        
        public string Barcode { get; set; } = string.Empty; // TODO: Prop own entity

        [Required]
        public DateTime ExpiryDateTime { get; set; } = default;

        [Required]
        public DateTime UseByDateTime { get; set; } = default;

        
        [Required]
        public Guid BrandId { get; set; } // ForeignKey        
        public Brand? Brand { get; set; } // Navigation property

                
        /// <summary>
        /// A product can have many various sizes, 2litre, 3litre, 4litre
        /// </summary>
        public IEnumerable<Measurement>? Measurements { get; set; }


#warning Re-think this
        //One-to-One Relationship
        [Required]
        public Quantity? Quantity { get; set; } // Navigation property

    }
}
