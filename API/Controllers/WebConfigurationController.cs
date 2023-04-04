using Application.Extensions;
using Application.Services;
using Application.Utilities;
using AutoMapper;
using BaseAPI.Controllers;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Models;
using Domain.Models.DomainModels;
using Domain.Requests;
using Domain.Searchs;
using Domain.Searchs.DomainSearchs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers
{
    /// <summary>
    /// WebConfigurationController
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class WebConfigurationController : ControllerBase
    {
        private readonly IWebConfigurationService _webConfigurationService;
        private readonly IMapper _mapper;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="serviceProvider"></param>
        public WebConfigurationController(IServiceProvider serviceProvider)
        {
            _webConfigurationService = serviceProvider.GetRequiredService<IWebConfigurationService>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
        }


        /// <summary>
        /// Get single WebConfiguration
        /// </summary>
        /// <returns></returns>
        [HttpGet("single")]
        [AppAuthorize((int)PermissionEnum.View)]
        public async Task<AppDomainResult> GetSingleAsync()
        {
            if (!ModelState.IsValid)
                throw new AppException(ModelState.GetErrorMessage());
            return new AppDomainResult
            {
                Data = await _webConfigurationService.GetWebConfiguration(),
                ResultCode = (int)HttpStatusCode.OK,
                ResultMessage = "Webconfiguration found",
                Success = true
            };
        }

        /// <summary>
        /// Get currency
        /// </summary>
        /// <returns></returns>
        [HttpGet("currency")]
        [AllowAnonymous]
        public async Task<AppDomainResult> GetCurrencyAsync()
        {
            if (!ModelState.IsValid)
                throw new AppException(ModelState.GetErrorMessage());
            return new AppDomainResult
            {
                Data = await _webConfigurationService.GetCurreny(),
                ResultCode = (int)HttpStatusCode.OK,
                ResultMessage = "Curreny found",
                Success = true
            };
        }

        /// <summary>
        /// Get single WebConfiguration
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [AppAuthorize((int)PermissionEnum.Update)]
        public async Task<AppDomainResult> UpdateAsync([FromBody] WebConfigurationRequest request)
        {
            if (!ModelState.IsValid)
                throw new AppException(ModelState.GetErrorMessage());
            bool success = await _webConfigurationService.UpdateAsync(request);

            return new AppDomainResult
            {
                Data = _mapper.Map<WebConfigurationModel>(request),
                ResultCode = (int)HttpStatusCode.OK,
                ResultMessage = "Webconfiguration found",
                Success = true
            };
        }
    }
}
