using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mickion.tuckshops.warehouse.domain.Entities
{
    public class Stock
    {
#warning - INCORRECT The ExpiryDateTime & UseByDateTime can only be done on Stock take
        [Required]
        public DateTime ExpiryDateTime { get; set; } = default;

        [Required]
        public DateTime UseByDateTime { get; set; } = default;
    }
}
