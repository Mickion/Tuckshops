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
    public class StockBrandsConfiguration : IEntityTypeConfiguration<StockBrand>
    {
        public void Configure(EntityTypeBuilder<StockBrand> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.CreatedDate)
                .IsRequired();

            builder.HasOne(x => x.CreatedBy)
                .WithMany()
                .HasForeignKey(x => x.CreatedById)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.ModifiedDate)
                .IsRequired();

            builder.HasOne(x => x.ModifiedBy)
                .WithMany()
                .HasForeignKey(x => x.ModifiedById)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.Name)
                .IsRequired();

        }
    }
}
