using Application.Extensions;
using Application.Utilities;
using AutoMapper;
using Domain.Interfaces;
using Domain.Requests.AuthRequests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BaseAPI.Controllers.Auths
{
    [ApiController]
    public abstract class AuthController : ControllerBase
    {
        protected IConfiguration _configuration;
        protected IMapper _mapper;
        protected readonly ILogger<AuthController> _logger;
        protected IAccountService _accountService;

        public AuthController(IServiceProvider serviceProvider, IConfiguration configuration, IMapper mapper, ILogger<AuthController> logger)
        {
            _logger = logger;
            _configuration = configuration;
            _mapper = mapper;
            _accountService = serviceProvider.GetRequiredService<IAccountService>();

        }

        /// <summary>
        /// Đăng nhập hệ thống
        /// </summary>
        /// <param name="loginRequest"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<AppDomainResult> LoginAsync([FromForm] LoginRequest loginRequest)
        {
            if (!ModelState.IsValid)
                throw new AppException(ModelState.GetErrorMessage());
            var token = await _accountService.LoginAsync(loginRequest.Username, loginRequest.Password);
            return new AppDomainResult()
            {
                Success = true,
                ResultCode = (int)HttpStatusCode.OK,
                Data = token,
                ResultMessage = "Login success"
            };
        }

        /// <summary>
        /// Đăng nhập hệ thống
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("register")]
        public virtual async Task<AppDomainResult> RegistrationAsync([FromBody] RegistrationRequest request)
        {
            if (!ModelState.IsValid)
                throw new AppException(ModelState.GetErrorMessage());
            var token = await _accountService.RegistrationAsync(request);
            return new AppDomainResult()
            {
                Success = true,
                Data = token,
                ResultCode = (int)HttpStatusCode.OK,
                ResultMessage = "Registration success"
            };
        }
    }
}
