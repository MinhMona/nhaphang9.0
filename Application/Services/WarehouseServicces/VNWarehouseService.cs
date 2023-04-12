using Application.Extensions;
using Application.Utilities;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
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
    public class VNWarehouseService : DomainService<Vnwarehouse, VNWarehouseRequest, BaseSearch>, IVNWarehouseService
    {
        public VNWarehouseService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        protected override string GetStoreProcName()
        {
            return "VNWarehousePaging";
        }

        public override async Task<bool> CreateAsync(VNWarehouseRequest request)
        {
            request.Code = ConvertNameToCode.ConvertToSlug(request.Name);
            await CheckName(request.Code);
            return await base.CreateAsync(request);
        }

        public override async Task<bool> UpdateAsync(VNWarehouseRequest request)
        {
            var vnWarehouse = await _unitOfWork.Repository<Vnwarehouse>().GetQueryable().FirstOrDefaultAsync(x => x.Id.Equals(request.Id));
            request.Code = ConvertNameToCode.ConvertToSlug(request.Name);
            if (!vnWarehouse.Code.Equals(request.Code))
                await CheckName(request.Code);
            return await base.UpdateAsync(request);
        }

        private async Task CheckName(string name)
        {
            var vnWarehouse = await _unitOfWork.Repository<Vnwarehouse>().GetQueryable().FirstOrDefaultAsync(s => s.Code.Equals(name));
            if (vnWarehouse != null)
                throw new AppException("VNWarehouse was existed");
        }
    }
}
