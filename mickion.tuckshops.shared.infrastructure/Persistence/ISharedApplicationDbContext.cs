namespace mickion.tuckshops.shared.infrastructure.Persistence
{
    public interface ISharedApplicationDbContext
    {
        public abstract Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken));
    }
}
