using Application.Utilities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System.Net;
using System.Reflection;
using System.Security;

namespace Application.Extensions
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class AppAuthorize : AuthorizeAttribute, IAuthorizationFilter
    {
        private readonly int Permission;
        public AppAuthorize(int permission)
        {
            Permission = permission;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = (LoginModel)context.HttpContext.Items["User"];
            if (user == null)
                throw new UnauthorizedAccessException("Unauthorized");
            string controllerName = string.Empty;
            if (context.ActionDescriptor is ControllerActionDescriptor descriptor)
                controllerName = descriptor.ControllerName;
            if (!user.IsAdmin)
            {
                var currentUser = LoginContext.Instance.CurrentUser ?? null;
                bool isPermission = true;
                if (currentUser != null)
                    isPermission = checkPermission(Permission, currentUser.RoleId, controllerName);
                if (!isPermission)
                    throw new UnauthorizedAccessException("Unauthorized");
            }
        }

        private bool checkPermission(int permission, int roleId, string controllerName)
        {
            Type permissionArrayType = typeof(PermissionArray);
            FieldInfo accountControllerField = permissionArrayType.GetField(controllerName);
            int[,] permissionArray = (int[,])accountControllerField.GetValue(null);
            int result = permissionArray[roleId, permission];
            return result == 1 ? true : false;
        }
    }
}
