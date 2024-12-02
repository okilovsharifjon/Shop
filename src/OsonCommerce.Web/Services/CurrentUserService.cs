using OsonCommerce.Application.Interfaces;
using System.Security.Claims;

namespace OsonCommerce.Web.Services
{
    public class CurrentUserService(IHttpContextAccessor httpContext) : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor = httpContext;

        public Guid UserId
        {
            get
            {
                var userIdClaim = _httpContextAccessor.HttpContext?.User?
                    .FindFirst(ClaimTypes.NameIdentifier);
                return userIdClaim == null ? Guid.Empty : Guid.Parse(userIdClaim.Value);
            }
        }
    }
    
}
