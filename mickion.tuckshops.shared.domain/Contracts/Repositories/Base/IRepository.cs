using mickion.tuckshops.shared.domain.Contracts.Entities;
using System.Linq.Expressions;

namespace mickion.tuckshops.shared.domain.Contracts.Repositories.Base;

/// <summary>
/// Generic Repository to be used by all projects.
/// All entities must implement the IEntity interface.
/// </summary>
/// <typeparam name="TEntity"></typeparam>
public interface IRepository<TEntity> where TEntity : class, IEntity
{
    #region Get data methods
    IQueryable<TEntity> GetAll();

    Task<IQueryable<TEntity>> GetAllAsync();

    TEntity? Find(Guid id);

    Task<TEntity?> FindAsync(Guid id);
    
    TEntity? Find(Expression<Func<TEntity, bool>> expression);

    Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> expression);

    IQueryable<TEntity?> Filter(Expression<Func<TEntity, bool>> expression);

    //Task<IQueryable<TEntity?>> FilterAsync(Expression<Func<TEntity, bool>> expression);

    #endregion

    #region Add,Delete,Edit Methods
    TEntity Add(TEntity entity);

    Task AddAsync(TEntity entity, CancellationToken cancellationToken);

    void Update(TEntity entity);

    void Delete(TEntity entity);
    #endregion
}
