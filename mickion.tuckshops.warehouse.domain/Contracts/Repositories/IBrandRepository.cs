using mickion.tuckshops.warehouse.domain.Entities;
using mickion.tuckshops.warehouse.domain.Contracts.Repositories.Base;

namespace mickion.tuckshops.warehouse.domain.Contracts.Repositories
{
    public interface IBrandRepository : IRepository<Brand> 
    {
#warning add cancellation token
        public Task<Brand> FindByNameAsync(string name);
    }
}
