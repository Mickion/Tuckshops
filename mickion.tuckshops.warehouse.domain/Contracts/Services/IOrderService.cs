using mickion.tuckshops.warehouse.domain.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mickion.tuckshops.warehouse.domain.Contracts.Services
{
    public interface IOrderService
    {
        Task OrderAsync(Guid productId, OrderType orderType);
        Task OrderAsync(Guid productId, OrderType orderType, Guid storeId);
    }
}
