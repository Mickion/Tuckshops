using mickion.tuckshops.warehouse.domain.Entities.Base;

namespace mickion.tuckshops.warehouse.domain.Entities
{
    public class StockQuantity: BaseEntity
    {
        public int StockOnHand { get; set; }

        public int StockOnOrder { get; set; }
    }
}
