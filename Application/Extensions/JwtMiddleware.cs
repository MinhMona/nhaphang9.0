using Application.Utilities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace Application.Extensions
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly AppSettings _appSettings;
        private readonly ITokenManagerService tokenManagerService;
        private ILogger<ControllerBase> _logger;
        public JwtMiddleware(RequestDelegate next, IOptions<AppSettings> appSettings, ITokenManagerService tokenManagerService, ILogger<ControllerBase> logger)
        {
            _next = next;
            _logger = logger;
            _appSettings = appSettings.Value;
            this.tokenManagerService = tokenManagerService;
        }

        public async Task Invoke(Microsoft.AspNetCore.Http.HttpContext context, IAccountService accountService)
        {
            try
            {
                var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

                if (await tokenManagerService.IsCurrentActiveToken())
                {
                    if (token != null)
                        attachUserToContext(context, accountService, token);
                    await _next(context);
                }
                else
                {
                    context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    var result = System.Text.Json.JsonSerializer.Serialize(new AppDomainResult()
                    {
                        ResultCode = context.Response.StatusCode,
                        Success = false
                    });
                    await context.Response.WriteAsync(result);
                }
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                switch (error)
                {
                    case AggregateException e:
                        response.StatusCode = (int)HttpStatusCode.Locked;
                        break;
                    case AppException e:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    case UnauthorizedAccessException e:
                        response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        break;
                    case InvalidCastException e:
                        response.StatusCode = (int)HttpStatusCode.Forbidden;
                        break;
                    case EntryPointNotFoundException e:
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    case KeyNotFoundException e:
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    case TimeoutException e:
                        response.StatusCode = (int)HttpStatusCode.RequestTimeout;
                        break;
                    default:
                        {
                            var RouteData = context.Request.Path.Value.Split("/");
                            string apiName = string.Empty;
                            string actionName = string.Empty;

                            if (RouteData.Count() >= 2)
                                apiName = RouteData[1];
                            if (RouteData.Count() >= 3)
                                actionName = RouteData[2];

                            _logger.LogError(string.Format("{0} {1}: {2}", apiName
                                , actionName, error?.Message));
                            response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        }

                        break;
                }
                var result = System.Text.Json.JsonSerializer.Serialize(new AppDomainResult()
                {
                    ResultCode = response.StatusCode,
                    ResultMessage = error?.Message,
                    Success = false
                });

                await response.WriteAsync(result);
            }
        }
        private void attachUserToContext(Microsoft.AspNetCore.Http.HttpContext context, IAccountService accountService, string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var userModel = new LoginModel();
                var claim = jwtToken.Claims.First(x => x.Type == ClaimTypes.UserData);
                if (claim != null)
                {
                    userModel = JsonConvert.DeserializeObject<LoginModel>(claim.Value);
                }

                context.Items["User"] = userModel;
            }
            catch (Exception)
            {
                throw new UnauthorizedAccessException("Phiên đăng nhập hết hạn");
            }
        }
    }

}
