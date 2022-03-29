using System.Security.Claims;

namespace Common.AspNetCore;

public static class ClaimUtils
{
    public static int GetUserId(this ClaimsPrincipal principal)
    {
        if (principal == null)
            throw new ArgumentNullException(nameof(principal));

        return Convert.ToInt32(principal.FindFirst(ClaimTypes.NameIdentifier)?.Value);
    }
}