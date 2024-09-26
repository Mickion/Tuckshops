using mickion.tuckshops.warehouse.domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace mickion.tuckshops.warehouse.infrastructure.Persistence.Configurations
{
    public class StockBrandConfiguration : IEntityTypeConfiguration<StockBrand>
    {
        public void Configure(EntityTypeBuilder<StockBrand> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
