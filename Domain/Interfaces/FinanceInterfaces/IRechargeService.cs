using Domain.Entities;
using Domain.Requests.FinanceRequests;
using Domain.Searchs;
using Domain.Searchs.FinanceSearchs;

namespace Domain.Interfaces.FinanceInterfaces
{
    public interface IRechargeService : IDomainService<Recharge, RechargeRequest, RechargeSearch>
    {
        Task<string> GetDataJson(RechargeSearch search);
    }
}
