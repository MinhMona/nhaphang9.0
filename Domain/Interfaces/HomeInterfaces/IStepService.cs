using Domain.Entities;
using Domain.Requests.HomePageRequests;
using Domain.Searchs.HomePageSearchs;

namespace Domain.Interfaces.HomeInterfaces
{
    public interface IStepService : IDomainService<Step, HomeRequest, HomeSearch>
    {
    }
}
