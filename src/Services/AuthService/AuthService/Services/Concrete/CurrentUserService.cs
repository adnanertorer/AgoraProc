using System.Security.Claims;
using AuthService.Services.Abstracts;
using Microsoft.AspNetCore.Http;

namespace AuthService.Services.Concrete;

public class CurrentUserService(IHttpContextAccessor httpContextAccessor) : ICurrentUserService
{
    public string? Id => httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    public string? UserName => httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(c => c.Type == "preferred_username")?.Value;
    public string? Email => httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.Email)?.Value;
    public List<string>? Roles => httpContextAccessor.HttpContext?.User
        .FindAll(ClaimTypes.Role).Select(r => r.Value).ToList();

    public string? Token
    {
        get
        {
            var authorizationHeader = httpContextAccessor.HttpContext?.Request.Headers["Authorization"].ToString();
            if (!string.IsNullOrEmpty(authorizationHeader) && authorizationHeader.StartsWith("Bearer "))
            {
                return authorizationHeader.Substring("Bearer ".Length).Trim();
            }
            return null;
        }
    }
}