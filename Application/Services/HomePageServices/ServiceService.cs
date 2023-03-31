using Application.Extensions;
using Application.Utilities;
using AutoMapper;
using Azure.Core;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.HomeInterfaces;
using Domain.Requests;
using Domain.Requests.HomePageRequests;
using Domain.Searchs;
using Domain.Searchs.DomainSearchs;
using Domain.Searchs.HomePageSearchs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.HomePageServices
{
    public class ServiceService : DomainService<Service, HomeRequest, HomeSearch>, IServiceService
    {
        public ServiceService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
        protected override string GetStoreProcName()
        {
            return "ServicePaging";
        }

        public override async Task<bool> CreateAsync(HomeRequest request)
        {
            request.Code = ConvertNameToCode.ConvertToSlug(request.Name);
            await CheckName(request.Code);
            return await base.CreateAsync(request);
        }

        public override async Task<bool> UpdateAsync(HomeRequest request)
        {
            var service = await _unitOfWork.Repository<Service>().GetQueryable().FirstOrDefaultAsync(s => s.Code.Equals(request.Code));
            request.Code = ConvertNameToCode.ConvertToSlug(request.Name);
            if (!service.Code.Equals(request.Code))
                await CheckName(request.Code);
            return await base.UpdateAsync(request);
        }

        private async Task CheckName(string name)
        {
            var service = await _unitOfWork.Repository<Service>()
            .GetQueryable()
                .FirstOrDefaultAsync(s => s.Code.Equals(name));
            if (service != null)
                throw new AppException("Service was existed");
        }
    }
}
