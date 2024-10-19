using mickion.tuckshops.shared.domain.Contracts.Entities;
using mickion.tuckshops.shared.domain.Entities;

namespace mickion.tuckshops.warehouse.domain.Entities
{
    public class Measurement: BaseEntity, IEntity
    {
        public double Size { get; set; } // 500 ml, 2.5kg etc

        public string Type { get; set; } = string.Empty; // kg, mg, litre

        //We can have many products that are 500mg or 2 litres
        public ICollection<Product> Products { get; set; } = [];
    }
}
