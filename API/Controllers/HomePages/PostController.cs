using Application.Extensions;
using Application.Services.HomePageServices;
using Application.Utilities;
using BaseAPI.Controllers;
using Domain.Common;
using Domain.Entities;
using Domain.Interfaces.HomeInterfaces;
using Domain.Models.HomePageModels;
using Domain.Requests.HomePageRequests;
using Domain.Searchs.DomainSearchs;
using Domain.Searchs.HomePageSearchs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace API.Controllers.HomePages
{
    /// <summary>
    /// PostController
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : BaseController<Post, PostModel, PostRequest, PostSearch>
    {
        private readonly IPostService _postService;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <param name="logger"></param>
        /// <param name="env"></param>
        public PostController(IServiceProvider serviceProvider, ILogger<ControllerBase> logger, IWebHostEnvironment env) : base(serviceProvider, logger, env)
        {
            _postService = serviceProvider.GetRequiredService<IPostService>();
            _domainService = _postService;
        }

        /// <summary>
        /// Get all post
        /// </summary>
        /// <returns></returns>
        public override async Task<AppDomainResult> GetPaging([FromQuery] PostSearch baseSearch)
        {
            if (!ModelState.IsValid)
                throw new AppException(ModelState.GetErrorMessage());
            return await Task.Run(() =>
            {
                return new AppDomainResult
                {
                    Data = _postService.GetPaging(baseSearch),
                    Success = true,
                    ResultCode = (int)HttpStatusCode.OK
                };
            });
        }
    }
}
