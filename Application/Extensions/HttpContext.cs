using Microsoft.AspNetCore.Http;

namespace Application.Extensions
{
    public static class HttpContext
    {
        private static IHttpContextAccessor _contextAccessor;

        public static Microsoft.AspNetCore.Http.HttpContext Current => _contextAccessor.HttpContext;

        public static void Configure(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }
    }
}
