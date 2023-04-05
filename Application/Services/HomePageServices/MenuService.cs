using Application.Extensions;
using Application.Utilities;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.HomeInterfaces;
using Domain.Requests.HomePageRequests;
using Domain.Searchs.HomePageSearchs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.HomePageServices
{
    public class MenuService : DomainService<Menu, HomeRequest, HomeSearch>, IMenuService
    {
        public MenuService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
        protected override string GetStoreProcName()
        {
            return "MenuPaging";
        }
        public override async Task<bool> CreateAsync(HomeRequest request)
        {
            request.Code = ConvertNameToCode.ConvertToSlug(request.Name);
            await CheckName(request.Code);
            bool success = await base.CreateAsync(request);
            if (success)
            {
                string data = await _unitOfWork.QueryRepository().ExcuteStoreNoneInput("MenuJson", "Menu");
                WriteDataToHomeJson.WriteData(data, "Menu");
            }
            return true;
        }

        public override async Task<bool> UpdateAsync(HomeRequest request)
        {
            var service = await _unitOfWork.Repository<Service>().GetQueryable().FirstOrDefaultAsync(s => s.Id.Equals(request.Id));
            request.Code = ConvertNameToCode.ConvertToSlug(request.Name);
            if (!service.Code.Equals(request.Code))
                await CheckName(request.Code);
            bool success = await base.UpdateAsync(request);
            if (success)
            {
                string data = await _unitOfWork.QueryRepository().ExcuteStoreNoneInput("MenuJson", "Menu");
                WriteDataToHomeJson.WriteData(data, "Menu");
            }
            return true;
        }
        private async Task CheckName(string name)
        {
            var service = await _unitOfWork.Repository<Menu>().GetQueryable().FirstOrDefaultAsync(s => s.Code.Equals(name));
            if (service != null)
                throw new AppException("Menu was existed");
        }
    }
}
