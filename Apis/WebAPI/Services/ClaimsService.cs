using Application.Interfaces;
using System.Security.Claims;

namespace WebAPI.Services
{
    public class ClaimsService : IClaimsService
    {
        public ClaimsService(IHttpContextAccessor httpContextAccessor)
        {
            // todo implementation to get the current userId
            var Id = httpContextAccessor.HttpContext?.User?.FindFirstValue("userId");
            GetCurrentUserId = string.IsNullOrEmpty(Id) ? Guid.Empty : Guid.Parse(Id);
            var role = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Role);
            GetCurrentUserRole = string.IsNullOrEmpty(role) ? string.Empty : role;
        }

        public Guid GetCurrentUserId { get; }
        public string GetCurrentUserRole { get; }
    }
}
