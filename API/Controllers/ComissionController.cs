using Application.Extensions;
using Application.Services;
using Application.Utilities;
using AutoMapper;
using Domain.Interfaces;
using Domain.Interfaces.HomeInterfaces;
using Domain.Requests;
using Domain.Searchs;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers
{
    /// <summary>
    /// Commission
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ComissionController : ControllerBase
    {
        private readonly ICommissionService _comissionService;
        /// <summary>
        /// Contructor
        /// </summary>
        public ComissionController(IServiceProvider serviceProvider)
        {
            _comissionService = serviceProvider.GetRequiredService<ICommissionService>();
        }


        [HttpPut]
        [AppAuthorize((int)PermissionEnum.Update)]
        public async Task<AppDomainResult> UpdateAsync([FromBody] CommissionRequest request)
        {
            return new AppDomainResult()
            {
                ResultCode = (int)HttpStatusCode.OK,
                Success = true
            };
        }

        [HttpGet]
        [AppAuthorize((int)PermissionEnum.View)]
        public async Task<AppDomainResult> GetPaging([FromQuery] CommissionSearch baseSearch)
        {
            return new AppDomainResult()
            {
                ResultCode = (int)HttpStatusCode.OK,
                Success = true
            };
        }
    }
}
