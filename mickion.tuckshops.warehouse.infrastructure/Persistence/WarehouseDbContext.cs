using Microsoft.EntityFrameworkCore;
using mickion.tuckshops.warehouse.domain.Entities;
using mickion.tuckshops.warehouse.infrastructure.Persistence.Configurations;
using System.Reflection;
using mickion.tuckshops.shared.infrastructure.Persistence;
using mickion.tuckshops.shared.domain.Entities;

namespace mickion.tuckshops.warehouse.infrastructure.Persistence
{
    // TODO: Notes for documentation
    // Add-Migration InitWarehouseDb -Context WarehouseDbContext -Project mickion.tuckshops.warehouse.infrastructure
    public class WarehouseDbContext(DbContextOptions<WarehouseDbContext> options) : AuditFieldsDbContext(options)
    {
        public DbSet<Brand>? Brands { get; set; }

        public DbSet<Product>? Products { get; set; }

        public DbSet<Measurement>? Measurements { get; set; }

        public DbSet<Quantity>? Quantities { get; set; }

        public override UserEntity GetLoggedInUserIdentity()
        {
#warning todo - call user service rest api??
            return new UserEntity
            {
                Id = new Guid("443abd91-22cb-443f-a8ef-c7db9247b594"),
                FirstName = "Mickion", LastName = "Mazibuko", CreatedDate = DateTime.Now, 
                CreatedByUserId= new Guid("443abd91-22cb-443f-a8ef-c7db9247b594")
            };
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Product>().HasIndex(x => x.Name);

            //modelBuilder.ApplyConfiguration(new BrandConfiguration());
            //modelBuilder.ApplyConfiguration(new MeasurementConfiguration());
            //modelBuilder.ApplyConfiguration(new ProductConfiguration());
            //modelBuilder.ApplyConfiguration(new QuantityConfiguration());            
        }
    }
}
