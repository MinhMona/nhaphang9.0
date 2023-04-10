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
    /// FeeBuyProductController
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class FeeBuyProductController : BaseController<FeeBuyProduct, FeeBuyProductModel, FeeBuyProductRequest, FeeBuyProductSearch>
    {
        private readonly IFeeBuyProductService _feeBuyProductService;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <param name="logger"></param>
        /// <param name="env"></param>
        public FeeBuyProductController(IServiceProvider serviceProvider, ILogger<ControllerBase> logger, IWebHostEnvironment env) : base(serviceProvider, logger, env)
        {
            _feeBuyProductService = serviceProvider.GetRequiredService<IFeeBuyProductService>();
            _domainService = _feeBuyProductService;
        }
    }
}
