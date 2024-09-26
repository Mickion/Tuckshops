using mickion.tuckshops.warehouse.domain.Entities.Base;

namespace mickion.tuckshops.warehouse.domain.Entities
{
    public class StockBrand: BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        //public string Description { get; set; } = string.Empty;

        ////TODO : Extract to own entity
        //public string BrandProvider { get; set; } = string.Empty;
    }
}
