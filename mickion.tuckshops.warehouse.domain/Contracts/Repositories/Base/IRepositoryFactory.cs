
using mickion.tuckshops.warehouse.domain.Entities;
using mickion.tuckshops.shared.domain.Contracts.Repositories.Base;

namespace mickion.tuckshops.warehouse.domain.Contracts.Repositories.Base
{
    /// <summary>
    /// Repositories access properties.
    /// </summary>
    public interface IRepositoryFactory
    {
        IRepository<Brand> BrandRepository { get; }
        IRepository<Product> ProductRepository { get; }        
        IRepository<Measurement> MeasurementRepository { get; }
        IRepository<Quantity> QuantityRepository { get; }        
    }
}
