using Microsoft.EntityFrameworkCore;
using mickion.tuckshops.warehouse.domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace mickion.tuckshops.warehouse.infrastructure.Persistence.Configurations
{
    public class MeasurementConfiguration : BaseEntityConfiguration<Measurement>, IEntityTypeConfiguration<Measurement>
    {
        public void Configure(EntityTypeBuilder<Measurement> builder)
        {
            builder.ToTable("tblMeasurements");

            ConfigureKeys(builder);
            ConfigureProperties(builder);
        }

        private static void ConfigureKeys(EntityTypeBuilder<Measurement> builder)
        {
            builder.HasKey("Id");
        }

        private static void ConfigureProperties(EntityTypeBuilder<Measurement> builder)
        {
            ConfigureBaseProperties(builder);

            builder.Property("Size").HasColumnType("FLOAT").IsRequired();
            builder.Property("Type").HasColumnType("nvarchar(100)").IsRequired();
        }

    }
}
