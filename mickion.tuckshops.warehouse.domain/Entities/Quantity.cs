using mickion.tuckshops.shared.Entities;

namespace mickion.tuckshops.warehouse.domain.Entities
{
    public class Quantity: BaseEntity
    {
        public int StockOnHand { get; set; }

        public int StockOnOrder { get; set; }

        //One-to-One Relationship
        public Guid ProductId { get; set; }

        public Product Product { get; set; } = new Product();

    }
}
