using Application.Extensions;
using Application.Utilities;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Requests.HomePageRequests;
using Domain.Requests.WarehouseRequests;
using Domain.Searchs.DomainSearchs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.WarehouseServicces
{
    public class CNWarehouseService : DomainService<Cnwarehouse, CNWarehouseRequest, BaseSearch>, ICNWarehouseService
    {
        public CNWarehouseService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        protected override string GetStoreProcName()
        {
            return "CNWarehousePaging";
        }

        public override async Task<bool> CreateAsync(CNWarehouseRequest request)
        {
            request.Code = ConvertNameToCode.ConvertToSlug(request.Name);
            await CheckName(request.Code);
            return await base.CreateAsync(request);
        }

        public override async Task<bool> UpdateAsync(CNWarehouseRequest request)
        {
            var cnWarehouse = await _unitOfWork.Repository<Cnwarehouse>().GetQueryable().FirstOrDefaultAsync(x => x.Id.Equals(request.Id));
            request.Code = ConvertNameToCode.ConvertToSlug(request.Name);
            if (!cnWarehouse.Code.Equals(request.Code))
                await CheckName(request.Code);
            return await base.UpdateAsync(request);
        }

        private async Task CheckName(string name)
        {
            var cnWarehouse = await _unitOfWork.Repository<Cnwarehouse>().GetQueryable().FirstOrDefaultAsync(s => s.Code.Equals(name));
            if (cnWarehouse != null)
                throw new AppException("CNWarehouse was existed");
        }
    }
}
