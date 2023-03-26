using Application.Utilities;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Extensions
{
    public sealed class LoginContext
    {
        private static LoginContext instance = null;

        private LoginContext()
        {
        }

        public static LoginContext Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LoginContext();
                }
                return instance;
            }
        }

        public LoginModel CurrentUser
        {
            get
            {
                var user = HttpContext.Current == null ? null : (LoginModel)HttpContext.Current.Items["User"];
                if (user != null)
                    return user;
                return null;
            }
        }

        public void Clear()
        {
            instance = null;
        }

        public LoginModel GetCurrentUser(IHttpContextAccessor httpContext)
        {
            if (httpContext != null && httpContext.HttpContext.User.Identity.IsAuthenticated)
            {
                var claim = httpContext.HttpContext.User.Claims.FirstOrDefault(e => e.Type == ClaimTypes.UserData);
                if (claim != null)
                    return JsonConvert.DeserializeObject<LoginModel>(claim.Value);
            }
            return null;
        }
    }
}
