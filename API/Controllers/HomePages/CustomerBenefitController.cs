using BaseAPI.Controllers;
using Domain.Entities;
using Domain.Interfaces.HomeInterfaces;
using Domain.Models.HomePageModels;
using Domain.Requests.HomePageRequests;
using Domain.Searchs.DomainSearchs;
using Domain.Searchs.HomePageSearchs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.HomePages
{
    /// <summary>
    /// CustomerBenefit
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerBenefitController : BaseController<CustomerBenefit, CustomerBenefitModel, CustomerBenefitRequest, CustomerBenefitSearch>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="ServiceProvider"></param>
        /// <param name="logger"></param>
        /// <param name="env"></param>
        public CustomerBenefitController(IServiceProvider ServiceProvider, ILogger<ControllerBase> logger, IWebHostEnvironment env) : base(ServiceProvider, logger, env)
        {
            _domainService = ServiceProvider.GetRequiredService<ICustomerBenefitService>();
        }
    }
}
