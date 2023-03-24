using Domain.Entities;
using Domain.Requests.AuthRequests;
using Domain.Requests;
using Domain.Searchs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Requests.DomainRequests;
using Domain.Searchs.DomainSearchs;

namespace Domain.Interfaces
{
    public interface IRoleService : IDomainService<Role, BaseRequest, BaseSearch>
    {
    }
}
