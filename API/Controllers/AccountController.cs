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
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseController<Account, AccountModel, AccountRequest, AccountSearch>
    {
        private readonly IAccountService _accountService;
        public AccountController(IServiceProvider serviceProvider, ILogger<ControllerBase> logger, IWebHostEnvironment env) : base(serviceProvider, logger, env)
        {
            _domainService = serviceProvider.GetRequiredService<IAccountService>();
            _accountService = serviceProvider.GetRequiredService<IAccountService>();
        }

        [AppAuthorize(new string[] { RoleNameConstant.Admin })]
        [HttpGet("{id}")]
        public override Task<AppDomainResult> GetById(Guid id)
        {
            return base.GetById(id);
        }

        [AppAuthorize(new string[] { RoleNameConstant.Admin })]
        [HttpPost]
        public override async Task<AppDomainResult> CreateAsync([FromBody] AccountRequest request)
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
