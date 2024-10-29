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

        //One-to-Many Relationship
        [Required]
        public Guid BrandId { get; set; } // ForeignKey        
        public Brand Brand { get; set; } = new Brand(); // Navigation property

        //One-to-Many Relationship
#warning Should have ProductMeasurement Table... 1lt coca cola, 2 litre coca cola etc...
        [Required]
        public Guid MeasurementsId { get; set; } // ForeignKey          
        public Measurement Measurements { get; set; } = new Measurement(); // Navigation property

        //One-to-One Relationship
        [Required]
        public Quantity Quantity { get; set; } = new Quantity(); // Navigation property

    }
}
