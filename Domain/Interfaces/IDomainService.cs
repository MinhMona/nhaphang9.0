using Domain.Common;
using Domain.Entities.DomainEntities;
using Domain.Requests.DomainRequests;
using Domain.Searchs.DomainSearchs;
using Microsoft.Data.SqlClient;

namespace Domain.Interfaces
{
    public interface IDomainService<E, R, S> where E : BaseEntity where R : BaseRequest where S : BaseSearch, new()
    {
        Task<bool> CreateAsync(R request);
        Task<bool> CreateAsync(IList<R> requests);
        Task<E> GetByIdAsync(Guid id);
        Task<bool> UpdateAsync(R request);
        Task<bool> UpdateAsync(IList<R> requests);
        Task<bool> DeleteAsync(Guid id);
        Task<PagedList<E>> GetPagedListData(S baseSearch);
        Task<string> GetJson(string storeName, S baseSearch);
    }
}
