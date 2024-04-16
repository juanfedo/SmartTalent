using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Infraestructura.Autenticacion
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class RequireClaimAttribute: Attribute, IAuthorizationFilter
    {

        readonly string _clainName;
        readonly string _claimValue;
        public RequireClaimAttribute(string claimValue, string clainName)
        {
            _claimValue = claimValue;
            _clainName = clainName;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.User.HasClaim(_clainName, _claimValue))
            {
                context.Result = new ForbidResult();
            }
        }
    }
}
