using Microsoft.EntityFrameworkCore;
using mickion.tuckshops.warehouse.domain.Entities;
using mickion.tuckshops.warehouse.infrastructure.Persistence.Configurations;
using System.Reflection;

namespace mickion.tuckshops.warehouse.infrastructure.Persistence
{
    // TODO: Notes for documentation
    // Add-Migration InitWarehouseDb -Context WarehouseDbContext -Project mickion.tuckshops.warehouse.infrastructure
    public class WarehouseDbContext(DbContextOptions<WarehouseDbContext> options) : DbContext(options)
    {
        public DbSet<Brand>? Brands { get; set; }

        public DbSet<Product>? Products { get; set; }

        public DbSet<Measurement>? Measurements { get; set; }

        public DbSet<Quantity>? Quantities { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.ApplyConfiguration(new BrandConfiguration());
            modelBuilder.ApplyConfiguration(new MeasurementConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new QuantityConfiguration());            
        }
    }
}
