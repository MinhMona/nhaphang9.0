using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Requests;
using Domain.Requests.DomainRequests;
using Domain.Searchs;
using Domain.Searchs.DomainSearchs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class RoleService : DomainService<Role, BaseRequest, BaseSearch>, IRoleService
    {
        public RoleService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
    }
}
