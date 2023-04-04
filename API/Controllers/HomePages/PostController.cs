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
    }
}
