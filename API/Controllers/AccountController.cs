using Application.Extensions;
using Application.Utilities;
using BaseAPI.Controllers;
using Domain.Common;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Models;
using Domain.Models.DomainModels;
using Domain.Requests;
using Domain.Searchs;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers
{
    /// <summary>
    /// AccountController
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseController<Account, AccountModel, AccountRequest, AccountSearch>
    {
        private readonly IAccountService _accountService;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <param name="logger"></param>
        /// <param name="env"></param>
        public AccountController(IServiceProvider serviceProvider, ILogger<ControllerBase> logger, IWebHostEnvironment env) : base(serviceProvider, logger, env)
        {
            _accountService = serviceProvider.GetRequiredService<IAccountService>();
            _domainService = _accountService;
        }

        /// <summary>
        /// Create new Account from SQL Query
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="AppException"></exception>
        [AppAuthorize((int)PermissionEnum.Add)]
        [HttpPost("add")]
        public async Task<AppDomainResult> CreateSQL([FromBody] AccountRequest request)
        {
            if (!ModelState.IsValid)
                throw new AppException(ModelState.GetErrorMessage());
            bool success = await _accountService.InsertUser(request);
            return new AppDomainResult()
            {
                Success = success,
                Data = request,
                ResultCode = (int)HttpStatusCode.OK,
                ResultMessage = "Create entity success"
            };
        }

        /// <summary>
        /// Get paging json
        /// </summary>
        /// <param name="baseSearch"></param>
        /// <returns></returns>
        /// <exception cref="AppException"></exception>
        [AppAuthorize((int)PermissionEnum.View)]
        [HttpGet("paging")]
        public virtual async Task<AppDomainResult> GetPagingJson([FromQuery] AccountSearch baseSearch)
        {
            if (!ModelState.IsValid)
                throw new AppException(ModelState.GetErrorMessage());
            string pagedData = await _accountService.GetDataJson(baseSearch);
            return new AppDomainResult
            {
                Data = pagedData,
                Success = true,
                ResultCode = (int)HttpStatusCode.OK
            };
        }
    }
}
