
using Microsoft.EntityFrameworkCore;
using mickion.tuckshops.shared.domain.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace mickion.tuckshops.shared.infrastructure.Persistence
{
    /// <summary>
    /// Re-usable audit fields context when something changes
    /// </summary>
    public abstract class AuditFieldsDbContext(DbContextOptions options) : DbContext(options)
    {
        /// <summary>
        /// Gets user account of person making changes
        /// </summary>
        /// <returns></returns>        
        public abstract UserEntity GetLoggedInUserIdentity(); 

        /// <summary>
        /// Updates auditing fields when changes occur.
        /// </summary>
        /// <param name="acceptAllChangesOnSuccess"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            AuditEntityCreation();
            AuditEntityModification();

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        /// <summary>
        /// Audits entity creation
        /// </summary>
        private void AuditEntityCreation() =>            
            ChangeTracker.Entries().Where(e => e.State == EntityState.Added).ToList().ForEach(e =>
            {
                e.Property("CreatedDate").CurrentValue = DateTime.Now;
                e.Property("CreatedByUserId").CurrentValue = GetLoggedInUserIdentity().Id;
            });
        

        /// <summary>
        /// Audits entity modifications
        /// </summary>
        private void AuditEntityModification() =>        
            ChangeTracker.Entries().Where(e => e.State == EntityState.Modified).ToList().ForEach(e =>
            {
                e.Property("ModifiedDate").CurrentValue = DateTime.Now;
                e.Property("ModifiedByUserId").CurrentValue = GetLoggedInUserIdentity().Id;
            });        
    }
}
