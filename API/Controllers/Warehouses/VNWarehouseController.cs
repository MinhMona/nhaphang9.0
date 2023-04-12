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
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.HomePages
{
    /// <summary>
    /// VNWarehouseController
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class VNWarehouseController : BaseController<Vnwarehouse, VNWarehouseModel, VNWarehouseRequest, BaseSearch>
    {
        private readonly IVNWarehouseService _vNWarehouseService;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <param name="logger"></param>
        /// <param name="env"></param>
        public VNWarehouseController(IServiceProvider serviceProvider, ILogger<ControllerBase> logger, IWebHostEnvironment env) : base(serviceProvider, logger, env)
        {
            _vNWarehouseService = serviceProvider.GetRequiredService<IVNWarehouseService>();
            _domainService = _vNWarehouseService;
        }
    }
}
