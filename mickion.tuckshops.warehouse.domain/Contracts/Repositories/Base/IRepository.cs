using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mickion.tuckshops.warehouse.domain.Contracts.Repositories.Base
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();

        Task<IQueryable<TEntity>> GetAllAsync();

        //TODO: Find by expression function
        
        TEntity Find(int id);

        Task<TEntity> FindAsync(int id);
             
        void Add(TEntity entity);

        Task AddAsync(TEntity entity, CancellationToken cancellationToken);

        void Update(TEntity entity);

        void Delete(TEntity entity);        
    }
}
