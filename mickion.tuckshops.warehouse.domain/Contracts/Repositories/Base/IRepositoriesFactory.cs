using mickion.tuckshops.warehouse.domain.Entities;

namespace mickion.tuckshops.warehouse.domain.Contracts.Repositories.Base
{
    /// <summary>
    /// Repositories access properties.
    /// </summary>
    public interface IRepositoriesFactory
    {
        IRepository<Product> ProductRepository { get; }
        IBrandRepository BrandRepository { get; }
        IRepository<Measurement> MeasurementRepository { get; }
        IRepository<Quantity> QuantityRepository { get; }        
    }
}
