using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace NikaScrapApp.Web.Utility
{
    public static class SessionManager
    {
        private static IHttpContextAccessor _httpContextAccessor;

        public static void Configure(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        private static Dictionary<string, object> _sessionStorage = new Dictionary<string, object>();

        public const string UserId = "UserId";
        public const string UserName = "UserName";
        public const string RoleName = "RoleName";
        public const string RoleId = "RoleId";
        public const string ProfilePicture = "ProfilePicture"; 
       
        public static void Set(string key, string value)
        {
            _httpContextAccessor.HttpContext.Session.SetString(key, value);
        }

        public static string Get(string key)
        {
            return _httpContextAccessor.HttpContext.Session.GetString(key);
        }

        public static void Remove(string key)
        {
            _httpContextAccessor.HttpContext.Session.Remove(key);
        }

        public static void Clear()
        {
            _httpContextAccessor.HttpContext.Session.Clear();
        } 
    }
}
