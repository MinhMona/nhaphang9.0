using Domain.Entities;
using Domain.Requests.FeeConfigRequests;
using Domain.Searchs.DomainSearchs;
using Domain.Searchs.FeeConfigSearchs;

namespace Domain.Interfaces.FeeConfigInterfaces
{
    public interface IFeeBuyProductService : IDomainService<FeeBuyProduct, FeeBuyProductRequest, FeeBuyProductSearch>
    {
    }
}
