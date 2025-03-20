using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using TicketTango.Models;

namespace TicketTango.Filters
{
    public class userAuthorizeFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.Session.GetString("UserRole") != Roles.EventOrganizer.ToString())
            {
                context.Result = new RedirectToActionResult("Index", "Login", null);
            }
        }
    }
}
