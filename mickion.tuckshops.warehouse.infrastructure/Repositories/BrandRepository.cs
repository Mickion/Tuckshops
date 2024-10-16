using mickion.tuckshops.warehouse.domain.Contracts.Repositories;
using mickion.tuckshops.warehouse.domain.Entities;
using mickion.tuckshops.warehouse.infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace mickion.tuckshops.warehouse.infrastructure.Repositories
{
#warning Get by expressions "func"
    internal class BrandRepository(DbSet<Brand> dbSet) : Repository<Brand>(dbSet), IBrandRepository
    {
        private readonly DbSet<Brand> _dbSet = dbSet ?? throw new ArgumentNullException(nameof(dbSet));
        public Task<Brand> FindByNameAsync(string name) => _dbSet.FirstOrDefaultAsync(x => x.Name == name)!;        
    }
}
