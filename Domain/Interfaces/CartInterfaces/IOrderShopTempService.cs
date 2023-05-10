using Domain.Requests.CartRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.CartInterfaces
{
    public interface IOrderShopTempService
    {
        Task<bool> CreateAsync(OrderShopTempRequest request);
    }
}
