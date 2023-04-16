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
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.HomePageServices
{
    public class PostService : DomainService<Post, PostRequest, PostSearch>, IPostService
    {
        public PostService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
        protected override string GetStoreProcName()
        {
            return "PostPaging";
        }

        public override async Task<bool> CreateAsync(PostRequest request)
        {
            request.Code = ConvertNameToCode.ConvertToSlug(request.Name);
            await CheckName(request.Code);
            return await base.CreateAsync(request);
        }

        public override async Task<bool> UpdateAsync(PostRequest request)
        {
            var post = await _unitOfWork.Repository<Post>().GetQueryable().FirstOrDefaultAsync(s => s.Id.Equals(request.Id));
            request.Code = ConvertNameToCode.ConvertToSlug(request.Name);
            if (!post.Code.Equals(request.Code))
                await CheckName(request.Code);

            return await base.UpdateAsync(request);
        }

        private async Task CheckName(string name)
        {
            var post = await _unitOfWork.Repository<Post>().GetQueryable().FirstOrDefaultAsync(s => s.Code.Equals(name));
            if (post != null)
                throw new AppException("Post was existed");
        }
    }
}
