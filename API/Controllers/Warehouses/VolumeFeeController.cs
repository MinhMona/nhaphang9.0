using BaseAPI.Controllers;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.HomeInterfaces;
using Domain.Models;
using Domain.Models.HomePageModels;
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
    /// VolumeFeeController
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class VolumeFeeController : BaseController<VolumeFee, VolumeFeeModel, VolumeFeeRequest, WarehouseFeeSearch>
    {
        private readonly IVolumeFeeService _volumeFeeService;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <param name="logger"></param>
        /// <param name="env"></param>
        public VolumeFeeController(IServiceProvider serviceProvider, ILogger<ControllerBase> logger, IWebHostEnvironment env) : base(serviceProvider, logger, env)
        {
            _volumeFeeService = serviceProvider.GetRequiredService<IVolumeFeeService>();
            _domainService = _volumeFeeService;
        }
    }
}
