using BaseAPI.Controllers;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.HomeInterfaces;
using Domain.Models.HomePageModels;
using Domain.Models.WarehouseModels;
using Domain.Requests.HomePageRequests;
using Domain.Requests.WarehouseRequests;
using Domain.Searchs.DomainSearchs;
using Domain.Searchs.HomePageSearchs;
using Domain.Searchs.WarehouseSearchs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.HomePages
{
    /// <summary>
    /// WeightFeeController
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class WeightFeeController : BaseController<WeightFee, WeightFeeModel, WeightFeeRequest, WarehouseFeeSearch>
    {
        private readonly IWeightFeeService _weightFeeService;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <param name="logger"></param>
        /// <param name="env"></param>
        public WeightFeeController(IServiceProvider serviceProvider, ILogger<ControllerBase> logger, IWebHostEnvironment env) : base(serviceProvider, logger, env)
        {
            _weightFeeService = serviceProvider.GetRequiredService<IWeightFeeService>();
            _domainService = _weightFeeService;
        }
    }
}
