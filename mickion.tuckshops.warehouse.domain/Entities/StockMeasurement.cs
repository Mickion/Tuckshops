using mickion.tuckshops.warehouse.domain.Entities.Base;

namespace mickion.tuckshops.warehouse.domain.Entities
{
    public class StockMeasurement: BaseEntity
    {
        public int Size { get; set; } // 500 ml, 1kg etc

        public string Type { get; set; } = string.Empty; // kg, mg, litre
    }
}
