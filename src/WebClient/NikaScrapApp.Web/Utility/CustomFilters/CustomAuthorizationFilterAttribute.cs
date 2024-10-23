using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System;

namespace NikaScrapApp.Web.Utility.CustomFilters
{
    public class CustomAuthorizationFilterAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            try
            {
                // Check if session value exists
                if (SessionManager.Get(SessionManager.UserId) == null)
                {
                    // If session does not exist, redirect to the login page
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Auth" }, { "action", "Login" } });
                }
            }
            catch (Exception ex)
            {
               
            }
        }

    }
}
