
using mickion.tuckshops.warehouse.domain.Entities;
using mickion.tuckshops.warehouse.infrastructure.Persistence;
using mickion.tuckshops.shared.domain.Contracts.Repositories.Base;
using mickion.tuckshops.warehouse.domain.Contracts.Repositories.Base;
using mickion.tuckshops.shared.infrastructure.Repositories.Base;

namespace mickion.tuckshops.warehouse.infrastructure.Repositories.Base
{
    /// <summary>
    /// Repositories factory
    /// </summary>
    /// <param name="dbContext"></param>
    public class RepositoryFactory(WarehouseDbContext dbContext) : RepositoryFactoryBase, IRepositoryFactory
    {        
        public IRepository<Brand> BrandRepository => GetRepository<Brand>(dbContext);

        public IRepository<Product> ProductRepository => GetRepository<Product>(dbContext);
       
        public IRepository<Measurement> MeasurementRepository => GetRepository<Measurement>(dbContext);

        public IRepository<Quantity> QuantityRepository => GetRepository<Quantity>(dbContext);        

    }
}
