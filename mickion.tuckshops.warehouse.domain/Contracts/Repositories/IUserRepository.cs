using mickion.tuckshops.warehouse.domain.Entities;
using mickion.tuckshops.warehouse.domain.Contracts.Repositories.Base;

namespace mickion.tuckshops.warehouse.domain.Contracts.Repositories
{
    //TODO: Move to its own service. Identity service
    public interface IUserRepository : IRepository<User> { }
}
