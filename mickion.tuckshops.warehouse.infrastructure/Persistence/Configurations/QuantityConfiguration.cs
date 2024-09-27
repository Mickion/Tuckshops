using mickion.tuckshops.warehouse.domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mickion.tuckshops.warehouse.infrastructure.Persistence.Configurations
{
    public class QuantityConfiguration : BaseEntityConfiguration<Quantity>, IEntityTypeConfiguration<Quantity>
    {
        public void Configure(EntityTypeBuilder<Quantity> builder)
        {
            builder.ToTable("tblQuantities");

            ConfigureKeys(builder);
            ConfigureProperties(builder);
        }

        private static void ConfigureKeys(EntityTypeBuilder<Quantity> builder)
        {
            builder.HasKey("Id");
        }

        private static void ConfigureProperties(EntityTypeBuilder<Quantity> builder)
        {
            ConfigureBaseProperties(builder);

            builder.Property("StockOnHand").HasColumnType("int").IsRequired();
            builder.Property("StockOnOrder").HasColumnType("int").IsRequired();
        }
    }
}
