
using mickion.tuckshops.warehouse.domain.Entities;
using mickion.tuckshops.warehouse.domain.Contracts.Repositories.Base;
using mickion.tuckshops.warehouse.infrastructure.Persistence;

namespace mickion.tuckshops.warehouse.infrastructure.Repositories.Base
{
    /// <summary>
    /// Repositories factory
    /// </summary>
    /// <param name="dbContext"></param>
    internal class Repositories(ApplicationDbContext dbContext) : IRepositories
    {
        private readonly ApplicationDbContext _dbContext = dbContext;
        private readonly Dictionary<Type, object> _repositories = new();

        public IRepository<StockItem> StockItemRepository => GetRepository<StockItem>();

        public IRepository<StockBrand> StockBrandRepository => GetRepository<StockBrand>();

        public IRepository<StockMeasurement> StockMeasurementRepository => GetRepository<StockMeasurement>();

        public IRepository<StockQuantity> StockQuantityRepository => GetRepository<StockQuantity>();


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
