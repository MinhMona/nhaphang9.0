using Application.Utilities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System.Net;

namespace Application.Extensions
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class AppAuthorize : AuthorizeAttribute, IAuthorizationFilter
    {
        private readonly string[] RoleNames;
        public AppAuthorize(string[] roleNames)
        {
            RoleNames = roleNames;
        }
        public async void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = (LoginModel)context.HttpContext.Items["User"];
            if (user == null)
            {
                //context.Result = JsonSerializer.Serialize(new AppDomainResult()
                //{
                //    ResultCode = (int)HttpStatusCode.Unauthorized,
                //    ResultMessage = "Không có quyền truy cập"
                //});
                throw new UnauthorizedAccessException("Không có quyền truy cập");
            }

            IAccountService _accountService = (IAccountService)context.HttpContext.RequestServices.GetRequiredService(typeof(IAccountService));
            if (!user.IsAdmin)
            {

                var currentUser = LoginContext.Instance.CurrentUser ?? null;
                bool isPermission = true;
                if (currentUser != null)
                    isPermission = await _accountService.HasPermission(currentUser.RoleId, RoleNames);
                if (!isPermission)
                {
                    //context.Result = new JsonSerializer.Serialize(new AppDomainResult()
                    //{
                    //    ResultCode = (int)HttpStatusCode.Unauthorized,
                    //    ResultMessage = "Không có quyền truy cập"
                    //});
                    throw new UnauthorizedAccessException("Không có quyền truy cập");
                }

            }
        }
    }
}
