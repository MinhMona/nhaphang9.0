using Application.Extensions;
using Application.Utilities;
using AutoMapper;
using Domain.Interfaces.CartInterfaces;
using Domain.Requests.CartRequests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers.Carts
{
    /// <summary>
    /// OrderShopTempController
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class OrderShopTempController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IOrderShopTempService _orderShopTempService;
        /// <summary>
        /// Constructor
        /// </summary>
        public OrderShopTempController(IServiceProvider serviceProvider)
        {
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _orderShopTempService = serviceProvider.GetRequiredService<IOrderShopTempService>();
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="AppException"></exception>
        [HttpPost]
        [AppAuthorize((int)PermissionEnum.Add)]
        public async Task<AppDomainResult> CreateAsync(OrderShopTempRequest request)
        {
            if (!ModelState.IsValid)
                throw new AppException(ModelState.GetErrorMessage());
            return new AppDomainResult
            {
                Data = await _orderShopTempService.CreateAsync(request),
                ResultCode = (int)HttpStatusCode.OK,
                ResultMessage = "Success",
                Success = true
            };
        }
    }
}
