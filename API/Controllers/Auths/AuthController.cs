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
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseAPI.Controllers.Auths.AuthController
    {
        public AuthController(IServiceProvider serviceProvider, IConfiguration configuration, IMapper mapper, ILogger<AuthController> logger) : base(serviceProvider, configuration, mapper, logger)
        {
        }        
    }
}
