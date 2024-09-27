using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace mickion.tuckshops.warehouse.infrastructure.Persistence.Configurations
{
    public class BaseEntityConfiguration <TEntity> where TEntity : class
    {
        public static void ConfigureBaseProperties(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property("Id").HasColumnType("uniqueidentifier");
            builder.Property("CreatedDate").HasColumnType("DATETIME");
            builder.Property("ModifiedDate").HasColumnType("DATETIME");
            builder.Property("CreatedByUserId").HasColumnType("uniqueidentifier");
            builder.Property("ModifiedByUserId").HasColumnType("uniqueidentifier");
        }
    }
}
