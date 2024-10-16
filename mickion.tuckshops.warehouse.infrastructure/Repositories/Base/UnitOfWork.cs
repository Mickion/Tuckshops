
using mickion.tuckshops.warehouse.infrastructure.Persistence;
using mickion.tuckshops.warehouse.domain.Contracts.Repositories.Base;

namespace mickion.tuckshops.warehouse.infrastructure.Repositories.Base
{
    // Internal to Infrastructure
    // Outside world don't need to know the implemantation details
    public class UnitOfWork(WarehouseDbContext dbContext): RepositoriesFactory(dbContext), IUnitOfWork
    {
        private readonly WarehouseDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

        public async Task CommitChangesAsync(CancellationToken cancellationToken = default) => await _dbContext.SaveChangesAsync(cancellationToken);

        public void CommitChanges() => _dbContext.SaveChanges();

        public void Dispose() => _dbContext.Dispose();        

    }
}
