using BaseAPI.Controllers;
using Domain.Entities;
using Domain.Interfaces.FeeConfigInterfaces;
using Domain.Models.FeeConfigModels;
using Domain.Requests.FeeConfigRequests;
using Domain.Searchs.DomainSearchs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.FeeConfigs
{
    /// <summary>
    /// UserLevelController
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserLevelController : BaseController<UserLevel, UserLevelModel, UserLevelRequest, BaseSearch>
    {
        private readonly IUserLevelService _userLevelService;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <param name="logger"></param>
        /// <param name="env"></param>
        public UserLevelController(IServiceProvider serviceProvider, ILogger<ControllerBase> logger, IWebHostEnvironment env) : base(serviceProvider, logger, env)
        {
            _userLevelService = serviceProvider.GetRequiredService<IUserLevelService>();
            _domainService = _userLevelService;
        }
    }
}
