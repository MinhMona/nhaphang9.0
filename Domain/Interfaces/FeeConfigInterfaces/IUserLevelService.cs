using Domain.Entities;
using Domain.Requests.FeeConfigRequests;
using Domain.Searchs.DomainSearchs;

namespace Domain.Interfaces.FeeConfigInterfaces
{
    public interface IUserLevelService : IDomainService<UserLevel, UserLevelRequest, BaseSearch>
    {
    }
}
