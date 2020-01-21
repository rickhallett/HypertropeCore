using System.Linq;
using System.Net.Http;
using Microsoft.AspNetCore.Http;

namespace HypertropeCore.Extensions
{
    public static class GeneralExtensions
    {
        public static string GetUserId(this HttpContext httpContext)
        {
            if (httpContext.User == null)
            {
                return string.Empty;
            }

            return httpContext.User.Claims.Single(c => c.Type == "id").Value;
        }
    }
}