using Microsoft.AspNetCore.Http;

namespace Cabify.Storefront.Services
{
    public class UserContext : IUserContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public string Name => _httpContextAccessor.HttpContext.User.FindFirst("name")?.Value;
        public string ImageUrl => _httpContextAccessor.HttpContext.User.FindFirst("picture")?.Value;
        public string Email => _httpContextAccessor.HttpContext.User.FindFirst("email")?.Value;

        public UserContext(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
    }
}
