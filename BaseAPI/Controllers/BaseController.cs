using Application.Extensions;
using Application.Utilities;
using AutoMapper;
using Domain.Common;
using Domain.Entities.DomainEntities;
using Domain.Interfaces;
using Domain.Models.DomainModels;
using Domain.Requests.DomainRequests;
using Domain.Searchs.DomainSearchs;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BaseAPI.Controllers
{
    /// <summary>
    /// Base API
    /// </summary>
    /// <typeparam name="E">Entity</typeparam>
    /// <typeparam name="M">Model</typeparam>
    /// <typeparam name="R">Request</typeparam>
    /// <typeparam name="S">SearchParam</typeparam>
    [ApiController]
    public abstract class BaseController<E, M, R, S> : ControllerBase where E : BaseEntity where M : BaseModel where R : BaseRequest where S : BaseSearch, new()
    {
        /// <summary>
        /// Log
        /// </summary>
        protected readonly ILogger<ControllerBase> _logger;
        /// <summary>
        /// ServiceProvider
        /// </summary>
        protected readonly IServiceProvider _serviceProvider;
        /// <summary>
        /// IWebHostEnvironment
        /// </summary>
        protected IWebHostEnvironment _env;
        /// <summary>
        /// DomainService
        /// </summary>
        protected IDomainService<E, R, S> _domainService;
        /// <summary>
        /// Auto Mapper
        /// </summary>
        protected readonly IMapper _mapper;

        /// <summary>
        /// Contructor
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <param name="logger"></param>
        /// <param name="env"></param>
        public BaseController(IServiceProvider serviceProvider, ILogger<ControllerBase> logger, IWebHostEnvironment env)
        {
            _env = env;
            _logger = logger;
            _serviceProvider = serviceProvider;
            _mapper = serviceProvider.GetRequiredService<IMapper>();
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [AppAuthorize((int)PermissionEnum.Add)]
        public virtual async Task<AppDomainResult> CreateAsync([FromBody] R request)
        {
            if (!ModelState.IsValid)
                throw new AppException(ModelState.GetErrorMessage());
            bool success = await _domainService.CreateAsync(request);
            return new AppDomainResult()
            {
                Success = success,
                Data = request,
                ResultCode = (int)HttpStatusCode.OK,
                ResultMessage = "Create entity success"
            };
        }

        /// <summary>
        /// Get by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public virtual async Task<AppDomainResult> GetById(Guid id)
        {
            var item = await _domainService.GetByIdAsync(id);
            return new AppDomainResult()
            {
                Success = true,
                Data = _mapper.Map<M>(item),
                ResultCode = (int)HttpStatusCode.OK,
                ResultMessage = "Entity found"
            };
        }

        /// <summary>
        /// Cập nhật thông tin item
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        [AppAuthorize((int)PermissionEnum.Update)]
        public virtual async Task<AppDomainResult> UpdateAsync([FromBody] R request)
        {
            if (!ModelState.IsValid)
                throw new AppException(ModelState.GetErrorMessage());
            bool success = await _domainService.UpdateAsync(request);
            return new AppDomainResult()
            {
                Success = success,
                Data = _mapper.Map<E>(request),
                ResultCode = (int)HttpStatusCode.OK,
                ResultMessage = "Update entity success"
            };
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [AppAuthorize((int)PermissionEnum.Delete)]
        public virtual async Task<AppDomainResult> DeleteAsync(Guid id)
        {
            return new AppDomainResult()
            {
                Success = await _domainService.DeleteAsync(id),
                ResultCode = (int)HttpStatusCode.OK,
                ResultMessage = "Delete entity success"
            };
        }

        /// <summary>
        /// Get paging
        /// </summary>
        /// <param name="baseSearch"></param>
        /// <returns></returns>
        [HttpGet]
        public virtual async Task<AppDomainResult> GetPaging([FromQuery] S baseSearch)
        {
            if (!ModelState.IsValid)
                throw new AppException(ModelState.GetErrorMessage());
            PagedList<E> pagedData = await _domainService.GetPagedListData(baseSearch);
            return new AppDomainResult
            {
                Data = _mapper.Map<PagedList<M>>(pagedData),
                Success = true,
                ResultCode = (int)HttpStatusCode.OK
            };
        }
    }
}
