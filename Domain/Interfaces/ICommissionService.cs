using Domain.Entities;
using Domain.Requests;
using Domain.Searchs;

namespace Domain.Interfaces.HomeInterfaces
{
    public interface ICommissionService : IDomainService<Commission, CommissionRequest, CommissionSearch>
    {
    }
}
