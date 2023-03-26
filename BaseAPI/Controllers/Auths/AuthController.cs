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
    /// <summary>
    /// Authentication Controller
    /// </summary>
    [ApiController]
    public abstract class AuthController : ControllerBase
    {
        /// <summary>
        /// IConfiguration
        /// </summary>
        protected IConfiguration _configuration;
        /// <summary>
        /// Auto Mapper
        /// </summary>
        protected IMapper _mapper;
        /// <summary>
        /// Log
        /// </summary>
        protected readonly ILogger<AuthController> _logger;
        /// <summary>
        /// AccountService
        /// </summary>
        protected IAccountService _accountService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <param name="configuration"></param>
        /// <param name="mapper"></param>
        /// <param name="logger"></param>
        public AuthController(IServiceProvider serviceProvider, IConfiguration configuration, IMapper mapper, ILogger<AuthController> logger)
        {
            _logger = logger;
            _configuration = configuration;
            _mapper = mapper;
            _accountService = serviceProvider.GetRequiredService<IAccountService>();
        }

        /// <summary>
        /// Login
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
        /// Registation
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
