using mickion.tuckshops.warehouse.domain.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace mickion.tuckshops.warehouse.domain.Entities
{
    // TODO: Refactor as I go
    // TODO: Normalize entities as I go
    // TODO: Move to common dll
    public class StockItem: BaseEntity
    {
        [Required]
        public string Code { get; set; } = string.Empty; //TODO: Generate unique code

        [Required]
        public string Name { get; set; } = string.Empty; // i.e. Bread

        public string Color { get; set; } = string.Empty; // i.e. White bread (optional)

        [Required]
        public string Barcode { get; set; } = string.Empty; // TODO: Prop own entity

        [Required]
        public DateTime ExpiryDateTime { get; set; } = default;

        public DateTime UseByDateTime { get; set; } = default;

        //[Required]
        //public Guid BrandId { get; set; }

        [Required]
        public StockBrand Brand { get; set; } = new StockBrand(); // i.e. Sasko

        [Required]
        public StockMeasurement Measurements { get; set; } = new StockMeasurement(); // 1 litre

        [Required]
        public StockQuantity Quantity { get; set; } = new StockQuantity(); // how many we have in stock on hand

    }
}
