using Application.Extensions;
using Application.Utilities;
using BaseAPI.Controllers;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Models;
using Domain.Models.DomainModels;
using Domain.Requests;
using Domain.Searchs;
using Domain.Searchs.DomainSearchs;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers
{
    /// <summary>
    /// WebConfigurationController
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class WebConfigurationController : BaseController<WebConfiguration, WebConfigurationModel, WebConfigurationRequest, BaseSearch>
    {
        private readonly IWebConfigurationService _webConfigurationService;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <param name="logger"></param>
        /// <param name="env"></param>
        public WebConfigurationController(IServiceProvider serviceProvider, ILogger<ControllerBase> logger, IWebHostEnvironment env) : base(serviceProvider, logger, env)
        {
            _domainService = serviceProvider.GetRequiredService<IWebConfigurationService>();
            _webConfigurationService = serviceProvider.GetRequiredService<IWebConfigurationService>();
        }


        /// <summary>
        /// Get single WebConfiguration
        /// </summary>
        /// <returns></returns>
        [HttpGet("get")]
        [AppAuthorize((int)PermissionEnum.View)]
        public async Task<AppDomainResult> GetSingleAsync()
        {
            return new AppDomainResult
            {
                Data = await _webConfigurationService.GetWebConfiguration(),
                ResultCode = (int)HttpStatusCode.OK,
                ResultMessage = "Webconfiguration found",
                Success = true
            };
        }
    }
}
