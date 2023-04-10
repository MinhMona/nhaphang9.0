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
    public class ShippingTypeService : DomainService<ShippingType, ShippingTypeRequest, BaseSearch>, IShippingTypeService
    {
        public ShippingTypeService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        protected override string GetStoreProcName()
        {
            return "ShippingTypePaging";
        }

        public override async Task<bool> CreateAsync(ShippingTypeRequest request)
        {
            request.Code = ConvertNameToCode.ConvertToSlug(request.Name);
            await CheckName(request.Code);
            return await base.CreateAsync(request);
        }

        public override async Task<bool> UpdateAsync(ShippingTypeRequest request)
        {
            var shippingType = await _unitOfWork.Repository<ShippingType>().GetQueryable().FirstOrDefaultAsync(x => x.Id.Equals(request.Id));
            request.Code = ConvertNameToCode.ConvertToSlug(request.Name);
            if (!shippingType.Code.Equals(request.Code))
                await CheckName(request.Code);
            return await base.UpdateAsync(request);
        }

        private async Task CheckName(string name)
        {
            var shippingType = await _unitOfWork.Repository<ShippingType>().GetQueryable().FirstOrDefaultAsync(s => s.Code.Equals(name));
            if (shippingType != null)
                throw new AppException("ShippingType was existed");
        }
    }
}
