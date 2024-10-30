using mickion.tuckshops.shared.domain.Contracts.Entities;
using mickion.tuckshops.shared.domain.Entities;

namespace mickion.tuckshops.warehouse.domain.Entities
{
    public class Measurement: BaseEntity, IEntity
    {
        /// <summary>
        /// Gets or sets 500 ml, 2.5kg etc
        /// </summary>
        public double Size { get; set; }

        /// <summary>
        /// Gets or sets kg, mg, litre
        /// </summary>
        public string Type { get; set; } = string.Empty;

        
        /// <summary>
        /// A Measurement, e.g. 1 litre can belong to many products
        /// </summary>
        public ICollection<Product> Products { get; set; } = [];

        ///// <summary>
        ///// Each 500ml has quantity values. How many cans we have??
        ///// </summary>
        //public Quantity? Quantity { get; set; }
    }
}
