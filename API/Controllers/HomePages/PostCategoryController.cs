using BaseAPI.Controllers;
using Domain.Entities;
using Domain.Interfaces.HomeInterfaces;
using Domain.Models.HomePageModels;
using Domain.Requests.HomePageRequests;
using Domain.Searchs.DomainSearchs;
using Domain.Searchs.HomePageSearchs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.HomePages
{
    /// <summary>
    /// PostCategory
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PostCategoryController : BaseController<PostCategory, PostCategoryModel, PostCategoryRequest, HomeSearch>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <param name="logger"></param>
        /// <param name="env"></param>
        public PostCategoryController(IServiceProvider serviceProvider, ILogger<ControllerBase> logger, IWebHostEnvironment env) : base(serviceProvider, logger, env)
        {
            _domainService = serviceProvider.GetRequiredService<IPostCategoryService>();
        }
    }
}
