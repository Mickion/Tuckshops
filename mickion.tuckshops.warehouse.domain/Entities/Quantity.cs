using mickion.tuckshops.shared.domain.Contracts.Entities;
using mickion.tuckshops.shared.domain.Entities;

namespace mickion.tuckshops.warehouse.domain.Entities
{
    public class Quantity: BaseEntity, IEntity
    {
        /// <summary>
        /// Gets or sets Product Measurement StockOnHand
        /// </summary>
        public int StockOnHand { get; set; }

        /// <summary>
        /// Gets or sets Product Measurement StockOnOrder
        /// </summary>
        public int StockOnOrder { get; set; }

        /// <summary>
        /// Each stock quantity belongs to Product + Measurement (i.e. 500mg bread)
        /// </summary>
        public Product? Product { get; set; }

        public Measurement? Measurement { get; set; }


        ///// <summary>
        ///// Gets or sets ProductsId
        ///// </summary>
        //public Guid QuantityId { get; set; }

        ///// <summary>
        ///// Each product measurement has quantity (i.e. 10x 500mg bread)
        ///// </summary>
        //public Quantity? Quantity { get; set; }
    }
}
