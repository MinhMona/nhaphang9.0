using Application.Extensions;
using Application.Utilities;
using BaseAPI.Controllers;
using Domain.Entities;
using Domain.Interfaces.FeeConfigInterfaces;
using Domain.Interfaces.FinanceInterfaces;
using Domain.Models.FeeConfigModels;
using Domain.Models.FinanceModels;
using Domain.Requests.FeeConfigRequests;
using Domain.Requests.FinanceRequests;
using Domain.Searchs;
using Domain.Searchs.DomainSearchs;
using Domain.Searchs.FeeConfigSearchs;
using Domain.Searchs.FinanceSearchs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers.Finances
{
    /// <summary>
    /// RechargeController
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class RechargeController : BaseController<Recharge, RechargeModel, RechargeRequest, RechargeSearch>
    {
        private readonly IRechargeService _rechargeService;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <param name="logger"></param>
        /// <param name="env"></param>
        public RechargeController(IServiceProvider serviceProvider, ILogger<ControllerBase> logger, IWebHostEnvironment env) : base(serviceProvider, logger, env)
        {
            _rechargeService = serviceProvider.GetRequiredService<IRechargeService>();
            _domainService = _rechargeService;
        }

        /// <summary>
        /// Get paging json
        /// </summary>
        /// <param name="baseSearch"></param>
        /// <returns></returns>
        /// <exception cref="AppException"></exception>
        [AppAuthorize((int)PermissionEnum.View)]
        [HttpGet("paging")]
        public virtual async Task<AppDomainResult> GetPagingJson([FromQuery] RechargeSearch baseSearch)
        {
            if (!ModelState.IsValid)
                throw new AppException(ModelState.GetErrorMessage());
            string pagedData = await _rechargeService.GetDataJson(baseSearch);
            return new AppDomainResult
            {
                Data = pagedData,
                Success = true,
                ResultCode = (int)HttpStatusCode.OK
            };
        }
    }
}
