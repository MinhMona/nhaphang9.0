﻿using Application.Extensions;
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
    public class CustomerBenefitService : DomainService<CustomerBenefit, CustomerBenefitRequest, CustomerBenefitSearch>, ICustomerBenefitService
    {
        public CustomerBenefitService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
        protected override string GetStoreProcName()
        {
            return "CustomerBenefitPaging";
        }

        public override async Task<bool> CreateAsync(CustomerBenefitRequest request)
        {
            request.Code = ConvertNameToCode.ConvertToSlug(request.Name);
            await CheckName(request.Code);
            bool success = await base.CreateAsync(request);
            if (success)
            {
                string data = await _unitOfWork.QueryRepository().ExcuteStoreNoneInput("CustomerBenefitJson", "CustomerBenefit");
                WriteDataToHomeJson.WriteData(data, "CustomerBenefit");
            }
            return true;
        }

        public override async Task<bool> UpdateAsync(CustomerBenefitRequest request)
        {
            var customerBenefit = await _unitOfWork.Repository<CustomerBenefit>().GetQueryable().FirstOrDefaultAsync(s => s.Id.Equals(request.Id));
            request.Code = ConvertNameToCode.ConvertToSlug(request.Name);
            if (!customerBenefit.Code.Equals(request.Code))
                await CheckName(request.Code);
            bool success = await base.UpdateAsync(request);
            if (success)
            {
                string data = await _unitOfWork.QueryRepository().ExcuteStoreNoneInput("CustomerBenefitJson", "CustomerBenefit");
                WriteDataToHomeJson.WriteData(data, "CustomerBenefit");
            }
            return true;
        }

        private async Task CheckName(string name)
        {
            var customerBenefit = await _unitOfWork.Repository<CustomerBenefit>().GetQueryable().FirstOrDefaultAsync(s => s.Code.Equals(name));
            if (customerBenefit != null)
                throw new AppException("CustomerBenefit was existed");
        }
    }
}
