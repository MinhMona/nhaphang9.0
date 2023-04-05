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
    public class PostCategoryService : DomainService<PostCategory, PostCategoryRequest, HomeSearch>, IPostCategoryService
    {
        public PostCategoryService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
        protected override string GetStoreProcName()
        {
            return "PostCategoryPaging";
        }

        public override async Task<bool> CreateAsync(PostCategoryRequest request)
        {
            request.Code = ConvertNameToCode.ConvertToSlug(request.Name);
            await CheckName(request.Code);
            return await base.CreateAsync(request);
        }

        public override async Task<bool> UpdateAsync(PostCategoryRequest request)
        {
            var postCategory = await _unitOfWork.Repository<PostCategory>().GetQueryable().FirstOrDefaultAsync(s => s.Id.Equals(request.Id));
            request.Code = ConvertNameToCode.ConvertToSlug(request.Name);
            if (!postCategory.Code.Equals(request.Code))
                await CheckName(request.Code);

            return  await base.UpdateAsync(request);
        }

        private async Task CheckName(string name)
        {
            var postCategory = await _unitOfWork.Repository<PostCategory>().GetQueryable().FirstOrDefaultAsync(s => s.Code.Equals(name));
            if (postCategory != null)
                throw new AppException("PostCategory was existed");
        }
    }
}
