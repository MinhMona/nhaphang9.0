using Application.Extensions;
using Application.Utilities;
using BaseAPI.Controllers;
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
            _domainService = serviceProvider.GetRequiredService<IAccountService>();
            _accountService = serviceProvider.GetRequiredService<IAccountService>();
        }

        /// <summary>
        /// Get Account By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [AppAuthorize(new string[] { RoleNameConstant.Admin, RoleNameConstant.EndUser })]
        [HttpGet("{id}")]
        public async override Task<AppDomainResult> GetById(Guid id)
        {
            return await base.GetById(id);
        }

        /// <summary>
        /// Update Account
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [AppAuthorize(new string[] { RoleNameConstant.Admin, RoleNameConstant.EndUser })]
        [HttpPut]
        public async override Task<AppDomainResult> UpdateAsync(AccountRequest request)
        {
            return await base.UpdateAsync(request);
        }

        /// <summary>
        /// Create new Account
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [AppAuthorize(new string[] { RoleNameConstant.Admin })]
        [HttpPost]
        public override async Task<AppDomainResult> CreateAsync([FromBody] AccountRequest request)
        {
            return await base.CreateAsync(request);
        }

        /// <summary>
        /// Create new Account from SQL Query
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="AppException"></exception>
        [AppAuthorize(new string[] { RoleNameConstant.Admin })]
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
    }
}
