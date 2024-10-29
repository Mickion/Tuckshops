using mickion.tuckshops.shared.domain.Contracts.Entities;
using mickion.tuckshops.shared.domain.Entities;

namespace mickion.tuckshops.warehouse.domain.Entities
{
    public class Brand: BaseEntity, IEntity
    {
        public string Name { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty; //TODO: Extract to own Shared Address Results

        ////TODO : Extract to own entity
        //public string BrandProvider { get; set; } = string.Empty;

        //A brand can have many products, i.e. Apple has iPhones, iPads etc..
        public IEnumerable<Product> Products { get; set; } = [];
    }
}
