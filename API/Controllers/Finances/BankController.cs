using BaseAPI.Controllers;
using Domain.Entities;
using Domain.Interfaces.FeeConfigInterfaces;
using Domain.Interfaces.FinanceInterfaces;
using Domain.Models.FeeConfigModels;
using Domain.Models.FinanceModels;
using Domain.Requests.FeeConfigRequests;
using Domain.Requests.FinanceRequests;
using Domain.Searchs.DomainSearchs;
using Domain.Searchs.FeeConfigSearchs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Finances
{
    /// <summary>
    /// BankController
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BankController : BaseController<Bank, BankModel, BankRequest, BaseSearch>
    {
        private readonly IBankService _bankService;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <param name="logger"></param>
        /// <param name="env"></param>
        public BankController(IServiceProvider serviceProvider, ILogger<ControllerBase> logger, IWebHostEnvironment env) : base(serviceProvider, logger, env)
        {
            _bankService = serviceProvider.GetRequiredService<IBankService>();
            _domainService = _bankService;
        }
    }
}
