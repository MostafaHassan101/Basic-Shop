using Azure.Core;
using BasicShop.Application.Common.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace WebApi.Services;
public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string UserId => _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
    //public string UserId => GetUserId();
    public string GetUserId()
    {
        var token = _httpContextAccessor.HttpContext?.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
        if (token != string.Empty)
        {
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token);
            var tokenS = handler.ReadToken(token) as JwtSecurityToken;
            var userId = tokenS.Claims.First(claim => claim.Type == "sub");

            return userId.Value;
        }

        return null;
    }
}