using System.Security.Claims;

namespace backend.Services
{
    public class UserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetCurrentUserId()
        {
            var user = _httpContextAccessor.HttpContext?.User;
            if (user == null || !user.Identity.IsAuthenticated)
            {
                return null; // No user is logged in
            }

            return user.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
