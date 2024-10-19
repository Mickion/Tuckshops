using mickion.tuckshops.warehouse.domain.Entities;

namespace mickion.tuckshops.warehouse.domain.Contracts.Repositories.Base
{
    // TODO: Unit of work article
    // this pattern acts as a bridge between the business logic and the data access layer
    // https://medium.com/@differentiate.function/understanding-unit-of-work-in-c-and-its-implementation-with-entity-framework-core-613552995237

    /*
     * Advantages of Using Unit of Work in C#:

        Consistent Data Changes: The Unit of Work pattern ensures that changes to multiple entities are committed or rolled back consistently, maintaining data integrity.
        Reduced Database Calls: By tracking changes within a unit of work and committing them in a single transaction, the number of database calls is minimized, leading to improved performance.
        Simplified Business Logic: Developers can focus on business logic without delving into transaction management complexities, resulting in more maintainable and readable code.
        Easy Rollback: In case of errors, the entire unit of work can be rolled back, simplifying error handling and ensuring a consistent database state.
     */
    public interface IUnitOfWork: IDisposable, IRepositoryFactory
    {        
        Task CommitChangesAsync(CancellationToken cancellationToken = default(CancellationToken));

        void CommitChanges();
    }
}
