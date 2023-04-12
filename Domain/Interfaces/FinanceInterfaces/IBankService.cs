using Domain.Entities;
using Domain.Requests.FinanceRequests;
using Domain.Searchs.DomainSearchs;

namespace Domain.Interfaces.FinanceInterfaces
{
    public interface IBankService : IDomainService<Bank, BankRequest, BaseSearch>
    {
    }
}
