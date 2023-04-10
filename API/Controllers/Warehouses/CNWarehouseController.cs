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
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.HomePages
{
    /// <summary>
    /// CNWarehouseController
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CNWarehouseController : BaseController<Cnwarehouse, CNWarehouseModel, CNWarehouseRequest, BaseSearch>
    {
        private readonly ICNWarehouseService _cNWarehouseService;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <param name="logger"></param>
        /// <param name="env"></param>
        public CNWarehouseController(IServiceProvider serviceProvider, ILogger<ControllerBase> logger, IWebHostEnvironment env) : base(serviceProvider, logger, env)
        {
            _cNWarehouseService = serviceProvider.GetRequiredService<ICNWarehouseService>();
            _domainService = _cNWarehouseService;
        }
    }
}
