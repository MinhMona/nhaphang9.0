using Domain.Entities;
using Domain.Models;
using Domain.Requests.AuthRequests;
using Domain.Requests.WarehouseRequests;
using Domain.Searchs;
using Domain.Searchs.DomainSearchs;

namespace Domain.Interfaces
{
    public interface IVNWarehouseService : IDomainService<Vnwarehouse, VNWarehouseRequest, BaseSearch>
    {

    }
}
