using Microsoft.AspNetCore.Mvc;

namespace AssignmentAPIs.services
{
    /// <summary>
    /// 
    /// </summary>
    public class AuthorizeAttribute : TypeFilterAttribute
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param ></param>
        public AuthorizeAttribute()
            : base(typeof(AuthorizationActionFilter))
        {
            Arguments = new object[] { };
        }
    }
}
