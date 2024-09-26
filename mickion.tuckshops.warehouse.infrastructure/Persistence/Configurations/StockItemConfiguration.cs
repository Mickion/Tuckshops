using mickion.tuckshops.warehouse.domain.Entities;
using Microsoft.Azure.Management.Sql.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace mickion.tuckshops.warehouse.infrastructure.Persistence.Configurations
{
    public class StockItemConfiguration : IEntityTypeConfiguration<StockItem>
    {
        public void Configure(EntityTypeBuilder<StockItem> builder)
        {
            builder.ToTable("tblStockItem");

            ConfigureKeys(builder);
            ConfigureProperties(builder);            
        }

        private static void ConfigureKeys(EntityTypeBuilder<StockItem> builder)
        {
            builder.HasKey(x => x.Id);
            //builder.HasOne(x => x.State).WithMany().HasForeignKey(x => x.StateId).HasConstraintName("FK_Token_State");
        }

        private static void ConfigureProperties(EntityTypeBuilder<StockItem> builder)
        {
            // TODO: Move HasColumnType to constants - public const string Varchar = "varchar";
            builder.Property(x => x.Id).HasColumnName("Id").HasColumnType("uniqueidentifier");
            builder.Property(x => x.Code).HasColumnName("Code").HasColumnType("nvarchar(100)");
            builder.Property(x => x.Name).HasColumnName("Name").HasColumnType("nvarchar(500)");
            builder.Property(x => x.Color).HasColumnName("Color").HasColumnType("nvarchar(500)");
            builder.Property(x => x.Barcode).HasColumnName("Barcode").HasColumnType("nvarchar(500)");
        }
        }
    }
}
