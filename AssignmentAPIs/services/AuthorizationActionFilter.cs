using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;
using System.Security.Claims;

namespace AssignmentAPIs.services
{/// <summary>
/// 
/// </summary>
    public class AuthorizationActionFilter : IAuthorizationFilter
    {
        private readonly string _permission;
        /// <summary>l
        /// 
        /// </summary>
        /// <param ></param>
        public AuthorizationActionFilter()
        {
            //_permission = permission;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            bool isAuthorized = CheckUserPermission(context.HttpContext.User, _permission);
            if (!isAuthorized)
            {
                context.Result = new UnauthorizedResult();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="permission"></param>
        /// <returns></returns>
        private bool CheckUserPermission(ClaimsPrincipal user, string permission)
        {
            if (user.Identity.IsAuthenticated)
            {
                var ExpireTime = Convert.ToInt32(user.Claims.First(claim => claim.Type == "exp").Value);
                var currentTime = Convert.ToInt32(DateTime.UtcNow.Subtract(new DateTime(1970, 01, 01)).TotalSeconds);
                if (ExpireTime > currentTime)
                {
                    return true;
                }

                else
                {
                    return false;
                }

            }
            else
            {
                return false;
            }

        }
    }
}
