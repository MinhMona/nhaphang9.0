using Application.Extensions;
using Application.Utilities;
using Domain.Entities.DomainEntities;
using Domain.Models.DomainModels;
using Domain.Requests.DomainRequests;
using Domain.Searchs.DomainSearchs;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BaseAPI.Controllers
{
    [ApiController]
    public abstract class BaseController<E, M, R, S> : ControllerBase where E : BaseEntity where M : BaseModel where R : BaseRequest where S : BaseSearch, new()
    {
        protected readonly ILogger<ControllerBase> logger;
        protected readonly IServiceProvider serviceProvider;
        protected IWebHostEnvironment env;
        protected IDomainService<E, R, S> domainService;

        public BaseController(IServiceProvider serviceProvider, ILogger<ControllerBase> logger, IWebHostEnvironment env)
        {
            this.env = env;
            this.logger = logger;
            this.serviceProvider = serviceProvider;
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public virtual async Task<AppDomainResult> CreateAsync([FromBody] R request)
        {
            if (!ModelState.IsValid)
                throw new AppException(ModelState.GetErrorMessage());
            bool success = await this.domainService.CreateAsync(request);
            return new AppDomainResult()
            {
                Success = success,
                Data = request,
                ResultCode = (int)HttpStatusCode.OK,
                ResultMessage = "Create entity success"
            };
        }
    }
}
