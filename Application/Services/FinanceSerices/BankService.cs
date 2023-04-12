using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.FeeConfigInterfaces;
using Domain.Interfaces.FinanceInterfaces;
using Domain.Requests.FeeConfigRequests;
using Domain.Requests.FinanceRequests;
using Domain.Searchs.DomainSearchs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.FinanceSerices
{
    public class BankService : DomainService<Bank, BankRequest, BaseSearch>, IBankService
    {
        public BankService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        protected override string GetStoreProcName()
        {
            return "BankPaging";
        }
    }
}
