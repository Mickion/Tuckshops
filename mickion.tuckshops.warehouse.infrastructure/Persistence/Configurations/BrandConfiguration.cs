using Microsoft.EntityFrameworkCore;
using mickion.tuckshops.warehouse.domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace mickion.tuckshops.warehouse.infrastructure.Persistence.Configurations
{
    public class BrandConfiguration : BaseEntityConfiguration<Brand>, IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.ToTable("tblBrands");

            ConfigureKeys(builder);
            ConfigureProperties(builder);
        }

        private static void ConfigureKeys(EntityTypeBuilder<Brand> builder)
        {
            builder.HasKey("Id");
        }

        private static void ConfigureProperties(EntityTypeBuilder<Brand> builder)
        {
            ConfigureBaseProperties(builder);

            builder.Property("Name").HasColumnType("nvarchar(100)").IsRequired();
            builder.Property("Address").HasColumnType("nvarchar(max)").IsRequired();
        }
    }
}
