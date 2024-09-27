using Microsoft.EntityFrameworkCore;
using mickion.tuckshops.warehouse.domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace mickion.tuckshops.warehouse.infrastructure.Persistence.Configurations
{
    // TODO: ref article EF Core HasForeignKey
    // https://www.learnentityframeworkcore.com/configuration/fluent-api/hasforeignkey-method

    // One-to-One Relationships using Fluent API in Entity Framework Core
    // https://www.entityframeworktutorial.net/efcore/configure-one-to-one-relationship-using-fluent-api-in-ef-core.aspx

    // One-to-Many Relationships using Fluent API in Entity Framework Core
    // https://www.entityframeworktutorial.net/efcore/configure-one-to-many-relationship-using-fluent-api-in-ef-core.aspx
    // ie. iPhone is a product && Apple is a brand. Apple sells many products
    public class ProductConfiguration : BaseEntityConfiguration<Product>, IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("tblProducts");

            ConfigureKeys(builder);
            ConfigureProperties(builder);            
        }

        private static void ConfigureKeys(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey("Id");

            //One-to-One Relationship
            builder
                .HasOne<Quantity>(qty => qty.Quantity).WithOne(pr => pr.Product).HasForeignKey<Quantity>(qty => qty.ProductId)
                .HasConstraintName("FK_Quantity_Product");

            //One-to-Many Relationship
            builder
                .HasOne<Brand>(prd => prd.Brand)
                .WithMany(brd => brd.Products)
                .HasForeignKey(prd => prd.BrandId).HasConstraintName("FK_Brand_Product");

            //One-to-Many Relationship
            builder
                .HasOne<Measurement>(prd => prd.Measurements)
                .WithMany(ms => ms.Products)
                .HasForeignKey(prd => prd.MeasurementsId).HasConstraintName("FK_Measurement_Product");
        }

        private static void ConfigureProperties(EntityTypeBuilder<Product> builder)
        {
            
            ConfigureBaseProperties(builder);

            // TODO: Move HasColumnType to constants - public const string Varchar = "varchar";
            builder.Property("Code").HasColumnType("nvarchar(100)").IsRequired();
            builder.Property("Name").HasColumnType("nvarchar(500)").IsRequired();
            builder.Property("Color").HasColumnType("nvarchar(100)");
            builder.Property("Barcode").HasColumnType("nvarchar(500)");
            builder.Property("ExpiryDateTime").HasColumnType("DATETIME").IsRequired();
            builder.Property("UseByDateTime").HasColumnType("DATETIME").IsRequired();
        }
        
    }
}
