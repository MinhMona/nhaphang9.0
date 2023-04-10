using Application.Extensions;
using Application.Utilities;
using AutoMapper;
using Azure.Core;
using Domain.Common;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.HomeInterfaces;
using Domain.Models.HomePageModels;
using Domain.Requests;
using Domain.Requests.HomePageRequests;
using Domain.Searchs;
using Domain.Searchs.DomainSearchs;
using Domain.Searchs.HomePageSearchs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Application.Services.HomePageServices
{
    public class PostService : DomainService<Post, PostRequest, PostSearch>, IPostService
    {
        private readonly IMemoryCache _cache;
        public PostService(IUnitOfWork unitOfWork, IMapper mapper, IMemoryCache cache) : base(unitOfWork, mapper)
        {
            _cache = cache;
        }
        protected override string GetStoreProcName()
        {
            return "PostPaging";
        }

        public override async Task<bool> CreateAsync(PostRequest request)
        {
            request.Code = ConvertNameToCode.ConvertToSlug(request.Name);
            await CheckName(request.Code);
            bool success = await base.CreateAsync(request);
            if (success)
                await CachePostsAsync();
            return true;
        }

        public override async Task<bool> UpdateAsync(PostRequest request)
        {
            var post = await _unitOfWork.Repository<Post>().GetQueryable().FirstOrDefaultAsync(s => s.Code.Equals(request.Code));
            request.Code = ConvertNameToCode.ConvertToSlug(request.Name);
            if (!post.Code.Equals(request.Code))
                await CheckName(request.Code);
            bool success = await base.UpdateAsync(request);
            if (success)
                await CachePostsAsync();
            return true;
        }

        //public PagedList<PostModel> GetPaging(PostSearch baseSearch)
        //{
        //    PagedList<PostModel> pagedList = new PagedList<PostModel>();
        //    pagedList.PageIndex = baseSearch.PageIndex;
        //    pagedList.PageSize = baseSearch.PageSize;
        //    int start = (baseSearch.PageIndex - 1) * baseSearch.PageSize;
        //    List<PostModel> postModels = null;
        //    postModels = _cache.Get<List<PostModel>>("PostCache");
        //    pagedList.Items = postModels.Skip(start).Take(baseSearch.PageSize).ToList();
        //    return pagedList;
        //}
        //private async Task CachePostsAsync()
        //{
        //    List<PostModel> postModels = null;
        //    if (!_cache.TryGetValue("PostCache", out postModels))
        //    {
        //        // Nếu chưa được cache thì lấy dữ liệu từ database
        //        var posts = await _unitOfWork.Repository<Post>().GetQueryable().ToListAsync();
        //        postModels = _mapper.Map<List<PostModel>>(posts);
        //        // Thêm dữ liệu vào cache với thời gian tồn tại là 5 phút
        //        var cacheEntryOptions = new MemoryCacheEntryOptions()
        //        .SetSlidingExpiration(TimeSpan.FromMinutes(1));

        //        _cache.Set("PostCache", postModels, cacheEntryOptions);
        //    }
        //}

        public PagedList<PostModel> GetPaging(PostSearch baseSearch)
        {
            PagedList<PostModel> pagedList = new PagedList<PostModel>();
            pagedList = _cache.Get<PagedList<PostModel>>($"PostCache_{baseSearch.PageIndex}");
            return pagedList;
        }
        private async Task CachePostsAsync()
        {
            var posts = await _unitOfWork.Repository<Post>().GetQueryable().ToListAsync();
            decimal totalItem = posts.Count;
            int pageSize = 10;
            int totalPage = (int)Math.Ceiling(totalItem / pageSize);
            for (int i = 1; i < totalPage + 1; i++)
            {
                PagedList<PostModel> listPost = null;

                listPost = new PagedList<PostModel>();
                listPost.PageSize = pageSize;
                listPost.PageIndex = i;
                int start = (listPost.PageIndex - 1) * pageSize;
                listPost.Items = _mapper.Map<List<PostModel>>(posts.Skip(start).Take(pageSize).ToList());
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromMinutes(30));
                _cache.Set($"PostCache_{i}", listPost, cacheEntryOptions);
            }
        }

        private async Task CheckName(string name)
        {
            var post = await _unitOfWork.Repository<Post>().GetQueryable().FirstOrDefaultAsync(s => s.Code.Equals(name));
            if (post != null)
                throw new AppException("Post was existed");
        }
    }
}
