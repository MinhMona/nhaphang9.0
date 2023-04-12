using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.FeeConfigInterfaces;
using Domain.Requests.FeeConfigRequests;
using Domain.Searchs.DomainSearchs;
using Domain.Searchs.FeeConfigSearchs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.FeeConfigServices
{
    public class FeeCheckProductService : DomainService<FeeCheckProduct, FeeCheckProductRequest, FeeCheckProductSearch>, IFeeCheckProductService
    {
        public FeeCheckProductService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
        protected override string GetStoreProcName()
        {
            return "FeeCheckProductPaging";
        }
    }
}
