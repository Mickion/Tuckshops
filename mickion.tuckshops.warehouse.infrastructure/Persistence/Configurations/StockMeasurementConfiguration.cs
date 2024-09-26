using mickion.tuckshops.warehouse.domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mickion.tuckshops.warehouse.infrastructure.Persistence.Configurations
{
    public class StockMeasurementConfiguration
    {
        public void Configure(EntityTypeBuilder<StockMeasurement> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
