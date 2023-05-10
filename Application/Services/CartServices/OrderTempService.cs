using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.CartInterfaces;
using Domain.Requests.CartRequests;
using Domain.Searchs.DomainSearchs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.CartServices
{
    public class OrderTempService : IOrderTempService
    {
        public OrderTempService(IUnitOfWork unitOfWork, IMapper mapper)
        {
        }
    }
}
