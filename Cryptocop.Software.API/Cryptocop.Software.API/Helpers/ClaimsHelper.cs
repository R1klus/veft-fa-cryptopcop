using System.Linq;
using System.Security.Claims;

namespace Cryptocop.Software.API.Helpers
{
    public static class ClaimsHelper
    {
        public static string GetClaim(ClaimsPrincipal user, string claim)
        {
            return user.Claims.FirstOrDefault(c => c.Type == claim)?.Value;
        }
    }
}