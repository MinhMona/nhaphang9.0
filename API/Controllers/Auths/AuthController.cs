using AutoMapper;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

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
        public AuthController(IServiceProvider serviceProvider, IConfiguration configuration, IMapper mapper, ILogger<AuthController> logger, IBackgroundNotiQueue queue, IServiceScopeFactory serviceScopeFactory) : base(serviceProvider, configuration, mapper, logger, queue, serviceScopeFactory)
        {
        }        
    }
}
