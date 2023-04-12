using Application.Extensions;
using Application.Services.HomePageServices;
using Application.Utilities;
using BaseAPI.Controllers;
using Domain.Entities;
using Domain.Interfaces.HomeInterfaces;
using Domain.Models.HomePageModels;
using Domain.Requests.HomePageRequests;
using Domain.Searchs.DomainSearchs;
using Domain.Searchs.HomePageSearchs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers.HomePages
{
    /// <summary>
    /// PostCategory
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PostCategoryController : BaseController<PostCategory, PostCategoryModel, PostCategoryRequest, HomeSearch>
    {
        private readonly IPostCategoryService _postCategoryService;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <param name="logger"></param>
        /// <param name="env"></param>
        public PostCategoryController(IServiceProvider serviceProvider, ILogger<ControllerBase> logger, IWebHostEnvironment env) : base(serviceProvider, logger, env)
        {
            _postCategoryService = serviceProvider.GetRequiredService<IPostCategoryService>();
            _domainService = _postCategoryService;
        }

        /// <summary>
        /// Get all post category
        /// </summary>
        /// <returns></returns>
        public override async Task<AppDomainResult> GetPaging([FromQuery] HomeSearch baseSearch)
        {
            if (!ModelState.IsValid)
                throw new AppException(ModelState.GetErrorMessage());
            return await Task.Run(() =>
            {
                return new AppDomainResult
                {
                    Data = _postCategoryService.GetAll(),
                    Success = true,
                    ResultCode = (int)HttpStatusCode.OK
                };
            });
        }
    }
}
