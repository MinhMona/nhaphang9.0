using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Requests.WarehouseRequests;
using Domain.Searchs.DomainSearchs;
using Domain.Searchs.WarehouseSearchs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.WarehouseServicces
{
    public class WeightFeeService : DomainService<WeightFee, WeightFeeRequest, WarehouseFeeSearch>, IWeightFeeService
    {
        public WeightFeeService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
        protected override string GetStoreProcName()
        {
            return "WeightFeePaging";
        }
    }
}
