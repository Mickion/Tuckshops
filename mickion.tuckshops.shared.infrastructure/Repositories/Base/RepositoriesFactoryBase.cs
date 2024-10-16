﻿using mickion.tuckshops.shared.domain.Contracts.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace mickion.tuckshops.shared.infrastructure.Repositories.Base
{
    public class RepositoriesFactoryBase
    {        
        private readonly Dictionary<Type, object> _repositories = [];

        /// <summary>
        /// New up repositories, only once.
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        public virtual IRepository<TEntity> GetRepository<TEntity>(DbContext dbContext) where TEntity : class
        {
            //Check if already new'd up the repo
            if (_repositories.ContainsKey(typeof(TEntity)))
            {
                return (IRepository<TEntity>)_repositories[typeof(TEntity)];
            }

            //If not new'd up before, new it up here then keep record of it.            
            var newRepositoryInstance = new Repository<TEntity>(dbContext.Set<TEntity>());
            _repositories.Add(typeof(TEntity), newRepositoryInstance);

            return newRepositoryInstance;
        }
    }
}
