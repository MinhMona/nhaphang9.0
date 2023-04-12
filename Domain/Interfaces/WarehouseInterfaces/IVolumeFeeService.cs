using Domain.Entities;
using Domain.Models;
using Domain.Requests.AuthRequests;
using Domain.Requests.WarehouseRequests;
using Domain.Searchs;
using Domain.Searchs.DomainSearchs;
using Domain.Searchs.WarehouseSearchs;

namespace Domain.Interfaces
{
    public interface IVolumeFeeService : IDomainService<VolumeFee, VolumeFeeRequest, WarehouseFeeSearch>
    {

    }
}
