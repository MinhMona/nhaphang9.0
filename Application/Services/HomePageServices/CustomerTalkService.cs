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
    public class CustomerTalkService : DomainService<CustomerTalk, HomeRequest, HomeSearch>, ICustomerTalkService
    {
        public CustomerTalkService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
        protected override string GetStoreProcName()
        {
            return "CustomerTalkPaging";
        }

        public override async Task<bool> CreateAsync(HomeRequest request)
        {
            request.Code = ConvertNameToCode.ConvertToSlug(request.Name);
            await CheckName(request.Code);
            bool success = await base.CreateAsync(request);
            if (success)
            {
                string data = await _unitOfWork.QueryRepository().ExcuteStoreNoneInput("CustomerTalkJson", "CustomerTalk");
                WriteDataToHomeJson.WriteData(data, "CustomerTalk");
            }
            return true;
        }

        public override async Task<bool> UpdateAsync(HomeRequest request)
        {
            var customerTalk = await _unitOfWork.Repository<CustomerTalk>().GetQueryable().FirstOrDefaultAsync(s => s.Id.Equals(request.Id));
            request.Code = ConvertNameToCode.ConvertToSlug(request.Name);
            if (!customerTalk.Code.Equals(request.Code))
                await CheckName(request.Code);
            bool success = await base.UpdateAsync(request);
            if (success)
            {
                string data = await _unitOfWork.QueryRepository().ExcuteStoreNoneInput("CustomerTalkJson", "CustomerTalk");
                WriteDataToHomeJson.WriteData(data, "CustomerTalk");
            }
            return true;
        }

        private async Task CheckName(string name)
        {
            var service = await _unitOfWork.Repository<CustomerTalk>().GetQueryable().FirstOrDefaultAsync(s => s.Code.Equals(name));
            if (service != null)
                throw new AppException("CustomerTalk was existed");
        }
    }
}
