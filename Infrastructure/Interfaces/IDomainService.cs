using Domain.Entities.DomainEntities;
using Domain.Models.DomainModels;
using Domain.Requests.DomainRequests;
using Domain.Searchs.DomainSearchs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IDomainService<E, R, S> where E : BaseEntity where R : BaseRequest where S : BaseSearch, new()
    {
        Task<bool> CreateAsync(R request);
        Task<bool> CreateAsync(IList<R> requests);
    }
}
