using Microsoft.EntityFrameworkCore;
using mickion.tuckshops.warehouse.domain.Contracts.Repositories.Base;

namespace mickion.tuckshops.warehouse.infrastructure.Repositories.Base
{
    internal class Repository<TEntity>(DbSet<TEntity> dbSet) : IRepository<TEntity> where TEntity : class
    {
        private readonly DbSet<TEntity> _dbSet = dbSet ?? throw new ArgumentNullException(nameof(dbSet));
        public void Add(TEntity entity) => _dbSet.Add(entity);

        public async Task AddAsync(TEntity entity, CancellationToken cancellationToken) => await _dbSet.AddAsync(entity, cancellationToken);
        
        public IQueryable<TEntity> GetAll() => _dbSet.AsQueryable();

        public async Task<IQueryable<TEntity>> GetAllAsync() => (IQueryable<TEntity>)await _dbSet.ToListAsync();


        public TEntity Find(int id)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> FindAsync(int id)
        {
            throw new NotImplementedException();
        }


        public void Update(TEntity entity) => _dbSet.Update(entity);

        public void Delete(TEntity entity) => _dbSet.Remove(entity);
    }
}
