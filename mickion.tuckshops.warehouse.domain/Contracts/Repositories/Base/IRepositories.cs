using mickion.tuckshops.warehouse.domain.Entities;

namespace mickion.tuckshops.warehouse.domain.Contracts.Repositories.Base
{
    /// <summary>
    /// Repositories access properties.
    /// </summary>
    public interface IRepositories
    {
        IRepository<StockItem> StockItemRepository { get; }
        IRepository<StockBrand> StockBrandRepository { get; }
        IRepository<StockMeasurement> StockMeasurementRepository { get; }
        IRepository<StockQuantity> StockQuantityRepository { get; }
    }
}
