namespace mickion.tuckshops.warehouse.domain.Contracts.Repositories.Base
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();

        Task<IQueryable<TEntity>> GetAllAsync();

#warning TODO: Find by expression function

        TEntity Find(Guid id);

        Task<TEntity> FindAsync(Guid id);
             
        TEntity Add(TEntity entity);

        Task AddAsync(TEntity entity, CancellationToken cancellationToken);

        void Update(TEntity entity);

        void Delete(TEntity entity);
        
    }
}
