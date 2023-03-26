using Application.Extensions;
using Application.Utilities;
using AutoMapper;
using Domain.Interfaces;
using Domain.Requests.AuthRequests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers.Auths
{
    /// <summary>
    /// AuthController
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseAPI.Controllers.Auths.AuthController
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <param name="configuration"></param>
        /// <param name="mapper"></param>
        /// <param name="logger"></param>
        public AuthController(IServiceProvider serviceProvider, IConfiguration configuration, IMapper mapper, ILogger<AuthController> logger) : base(serviceProvider, configuration, mapper, logger)
        {
        }        
    }
}
