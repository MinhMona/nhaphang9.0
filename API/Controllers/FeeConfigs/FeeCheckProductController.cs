using BaseAPI.Controllers;
using Domain.Entities;
using Domain.Interfaces.FeeConfigInterfaces;
using Domain.Models.FeeConfigModels;
using Domain.Requests.FeeConfigRequests;
using Domain.Searchs.DomainSearchs;
using Domain.Searchs.FeeConfigSearchs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.FeeConfigs
{
    /// <summary>
    /// FeeCheckProductController
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class FeeCheckProductController : BaseController<FeeCheckProduct, FeeCheckProductModel, FeeCheckProductRequest, FeeCheckProductSearch>
    {
        private readonly IFeeCheckProductService _feeCheckProductService;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <param name="logger"></param>
        /// <param name="env"></param>
        public FeeCheckProductController(IServiceProvider serviceProvider, ILogger<ControllerBase> logger, IWebHostEnvironment env) : base(serviceProvider, logger, env)
        {
            _feeCheckProductService = serviceProvider.GetRequiredService<IFeeCheckProductService>();
            _domainService = _feeCheckProductService;
        }
    }
}
