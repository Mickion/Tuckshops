using Microsoft.EntityFrameworkCore;
using mickion.tuckshops.warehouse.domain.Entities;
using mickion.tuckshops.warehouse.infrastructure.Persistence.Configurations;

namespace mickion.tuckshops.warehouse.infrastructure.Persistence
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) { }

        public DbSet<StockBrand>? StockBrands { get; set; }

        public DbSet<StockItem>? StockItems { get; set; }

        public DbSet<StockMeasurement>? StockMeasurements { get; set; }

        public DbSet<StockQuantity>? StockQuantities { get; set; }

        public DbSet<User>? Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) { 
            base.OnModelCreating(modelBuilder);

            // Add table configurations
            modelBuilder.ApplyConfiguration(new StockBrandsConfiguration());
        }
    }
}
