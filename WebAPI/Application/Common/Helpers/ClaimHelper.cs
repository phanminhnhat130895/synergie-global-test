using System.Security.Claims;

namespace Application.Common.Helpers
{
    public static class ClaimHelper
    {
        public static string GetUserId(this ClaimsPrincipal user)
        {
            return user.FindFirst(ClaimType.USERID)?.Value ?? "";
        }
    }
}
