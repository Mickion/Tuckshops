﻿using mickion.tuckshops.shared.domain.Contracts.Entities;
using System.Linq.Expressions;

namespace mickion.tuckshops.shared.domain.Contracts.Repositories.Base;

/// <summary>
/// Generic Repository to be used by all projects.
/// All entities must implement the IEntity interface.
/// </summary>
/// <typeparam name="TEntity"></typeparam>
public interface IRepository<TEntity> where TEntity : class, IAuditableEntity
{
    #region Get data methods
    IQueryable<TEntity> GetAll(bool readOnly = false);

    Task<IQueryable<TEntity>> GetAllAsync(CancellationToken cancellationToken=default, bool readOnly = false);

    TEntity? Find(Guid id);

    Task<TEntity?> FindAsync(Guid id, CancellationToken cancellationToken = default);
    
    TEntity? Find(Expression<Func<TEntity, bool>> expression, bool readOnly = false);

    Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default, bool readOnly = false);

    IQueryable<TEntity?> Filter(Expression<Func<TEntity, bool>> expression, bool readOnly = false);

    //Task<IQueryable<TEntity?>> FilterAsync(Expression<Func<TEntity, bool>> expression);

    #endregion

    #region Add,Delete,Edit Methods
#warning Add async methods for these
    TEntity Add(TEntity entity);

    Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken);

    void Update(TEntity entity);

    void Delete(TEntity entity);
    #endregion
}
