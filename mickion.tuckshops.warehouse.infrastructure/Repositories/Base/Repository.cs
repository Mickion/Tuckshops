using Microsoft.EntityFrameworkCore;
using mickion.tuckshops.warehouse.domain.Contracts.Repositories.Base;

namespace mickion.tuckshops.warehouse.infrastructure.Repositories.Base
{
    internal class Repository<TEntity>(DbSet<TEntity> dbSet) : IRepository<TEntity> where TEntity : class
    {
        private readonly DbSet<TEntity> _dbSet = dbSet ?? throw new ArgumentNullException(nameof(dbSet));
        public TEntity Add(TEntity entity)
        {            
            _dbSet.Add(entity);
            return entity;
        }

        public async Task AddAsync(TEntity entity, CancellationToken cancellationToken) => await _dbSet.AddAsync(entity, cancellationToken);
        
        public IQueryable<TEntity> GetAll() => _dbSet.AsQueryable();

        public async Task<IQueryable<TEntity>> GetAllAsync() => (IQueryable<TEntity>)await _dbSet.ToListAsync();

        public TEntity Find(Guid id) => _dbSet.Find(id)!;

        public async Task<TEntity> FindAsync(Guid id) => await _dbSet.FindAsync(id);   

        public void Update(TEntity entity) => _dbSet.Update(entity);

        public void Delete(TEntity entity) => _dbSet.Remove(entity);
    }
}
