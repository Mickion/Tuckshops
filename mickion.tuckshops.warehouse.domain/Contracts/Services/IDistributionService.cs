using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mickion.tuckshops.warehouse.domain.Contracts.Services
{
    public interface IDistributionService
    {
#warning todo - this will be called by StockIn as an event
        void Distribute(Guid productId);
    }
}
