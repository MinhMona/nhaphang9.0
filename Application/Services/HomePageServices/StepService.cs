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
    public class StepService : DomainService<Step, HomeRequest, HomeSearch>, IStepService
    {
        public StepService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
        protected override string GetStoreProcName()
        {
            return "StepPaging";
        }

        public override async Task<bool> CreateAsync(HomeRequest request)
        {
            request.Code = ConvertNameToCode.ConvertToSlug(request.Name);
            await CheckName(request.Code);
            return await base.CreateAsync(request);
        }

        public override async Task<bool> UpdateAsync(HomeRequest request)
        {
            var step = await _unitOfWork.Repository<Step>().GetQueryable().FirstOrDefaultAsync(s => s.Code.Equals(request.Code));
            request.Code = ConvertNameToCode.ConvertToSlug(request.Name);
            if (!step.Code.Equals(request.Code))
                await CheckName(request.Code);

            return await base.UpdateAsync(request);
        }

        private async Task CheckName(string name)
        {
            var step = await _unitOfWork.Repository<Step>().GetQueryable().FirstOrDefaultAsync(s => s.Code.Equals(name));
            if (step != null)
                throw new AppException("Step was existed");
        }
    }
}
