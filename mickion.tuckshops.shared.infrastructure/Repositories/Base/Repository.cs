using mickion.tuckshops.shared.domain.Contracts.Entities;
using mickion.tuckshops.shared.domain.Contracts.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq;
using System.Linq.Expressions;

namespace mickion.tuckshops.shared.infrastructure.Repositories.Base
{
    public class Repository<TEntity>(DbSet<TEntity> dbSet) : IRepository<TEntity> where TEntity : class, IEntity
    {
        #region Private variables
        private readonly DbSet<TEntity> _dbSet = dbSet ?? throw new ArgumentNullException(nameof(dbSet));
        #endregion

        #region Read data methods
        public IQueryable<TEntity> GetAll(bool readOnly = false)
            => readOnly ? _dbSet.AsNoTracking().AsQueryable() : _dbSet.AsQueryable();

        public async Task<IQueryable<TEntity>> GetAllAsync(bool readOnly = false)
            => readOnly ? (IQueryable<TEntity>)await _dbSet.AsNoTracking().ToListAsync() : (IQueryable<TEntity>)await _dbSet.ToListAsync();

        /// <summary>
        /// Gets by primary key
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TEntity? Find(Guid id) => _dbSet.Find(id);

        public async Task<TEntity?> FindAsync(Guid id) => await _dbSet.FindAsync(id);

#warning todo - add pagination
        /// <summary>
        /// Gets by lamba condition
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="readOnly"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public TEntity? Find(Expression<Func<TEntity, bool>> expression, bool readOnly = false) =>
            expression == null ? throw new ArgumentNullException(nameof(expression))
            : readOnly ? _dbSet.AsNoTracking().FirstOrDefault(expression) : _dbSet.FirstOrDefault(expression);

        public async Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> expression, bool readOnly = false) =>
            expression == null ? throw new ArgumentNullException(nameof(expression)) 
            : readOnly ? await _dbSet.AsNoTracking().FirstOrDefaultAsync(expression) : await _dbSet.FirstOrDefaultAsync(expression);

        public IQueryable<TEntity?> Filter(Expression<Func<TEntity, bool>> expression, bool readOnly = false) =>
            expression == null ? throw new ArgumentNullException(nameof(expression)) 
            : readOnly ? _dbSet.AsNoTracking().AsQueryable().Where(expression) : _dbSet.AsNoTracking().AsQueryable().Where(expression);

        //public async Task<IQueryable<TEntity?>> FindAsync(Expression<Func<IQueryable<TEntity?>, bool>> expression) =>
        //    expression == null ? throw new ArgumentNullException(nameof(expression)) : await _dbSet.AllAsync().Where(expression);

        #endregion

        #region CRUD Operations methods
        public TEntity Add(TEntity entity)
        {
            _dbSet.Add(entity);
            return entity;
        }

        public async Task AddAsync(TEntity entity, CancellationToken cancellationToken) => await _dbSet.AddAsync(entity, cancellationToken);

        public void Update(TEntity entity) => _dbSet.Update(entity);

        public void Delete(TEntity entity) => _dbSet.Remove(entity);

        #endregion
    }
}
