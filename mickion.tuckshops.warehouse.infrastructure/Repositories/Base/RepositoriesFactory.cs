
using mickion.tuckshops.warehouse.domain.Entities;
using mickion.tuckshops.warehouse.domain.Contracts.Repositories.Base;
using mickion.tuckshops.warehouse.infrastructure.Persistence;
using mickion.tuckshops.warehouse.domain.Contracts.Repositories;

namespace mickion.tuckshops.warehouse.infrastructure.Repositories.Base
{
    /// <summary>
    /// Repositories factory
    /// </summary>
    /// <param name="dbContext"></param>
    public class RepositoriesFactory(WarehouseDbContext dbContext) : IRepositoriesFactory
    {
        private readonly WarehouseDbContext _dbContext = dbContext;
        private readonly Dictionary<Type, object> _repositories = new();

        public IRepository<Product> ProductRepository => GetRepository<Product>();

        //public IRepository<Brand> BrandRepository => GetRepository<Brand>();

        public IRepository<Measurement> MeasurementRepository => GetRepository<Measurement>();

        public IRepository<Quantity> QuantityRepository => GetRepository<Quantity>();

#warning todo - relook at this and fix the bug
        public IBrandRepository BrandRepository => (IBrandRepository)GetRepository<Brand>();


        /// <summary>
        /// New up repositories, only once.
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        private IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            //Check if already new'd up the repo
            if (_repositories.ContainsKey(typeof(TEntity)))
            {
                return (IRepository<TEntity>)_repositories[typeof(TEntity)];
            }

            //If not new'd up before, new it up here then keep record of it.            
            var newRepositoryInstance = new Repository<TEntity>(_dbContext.Set<TEntity>());
            _repositories.Add(typeof(TEntity), newRepositoryInstance);

            return newRepositoryInstance;
        }
    }
}
