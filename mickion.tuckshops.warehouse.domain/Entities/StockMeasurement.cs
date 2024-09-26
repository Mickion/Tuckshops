using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mickion.tuckshops.warehouse.domain.Entities
{
    public class StockMeasurement
    {
        public int Size { get; set; } // 500 ml, 1kg etc

        public string Type { get; set; } = string.Empty; // kg, mg, litre
    }
}
