using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Utils
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class TokenAuthorizationAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.Items["User"];
        }
    }
}
