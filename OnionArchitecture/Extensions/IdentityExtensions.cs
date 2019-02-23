using System;
using System.Security.Claims;
using System.Security.Principal;

namespace OnionArchitecture.Extensions
{
    public static class IdentityExtensions
    {
        public static string FindFirstValue(this ClaimsIdentity identity, string claimType)
        {
            if (identity == null)
            {
                throw new ArgumentNullException(nameof(identity));
            }
            var claim = identity.FindFirst(claimType);
            return claim?.Value;
        }

        public static int? GetUserId(this IIdentity identity)
        {
            if (identity == null)
            {
                throw new ArgumentNullException(nameof(identity));
            }
            return !(identity is ClaimsIdentity claimsIdentity) ? (int?)null : int.Parse(claimsIdentity.FindFirstValue("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"));
        }

        public static string GetUserName(this IIdentity identity)
        {
            if (identity == null)
            {
                throw new ArgumentNullException(nameof(identity));
            }
            return !(identity is ClaimsIdentity claimsIdentity) ? null : claimsIdentity.FindFirstValue("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name");
        }
    }
}