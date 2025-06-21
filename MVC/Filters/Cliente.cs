using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MVC.Filters
{
    public class Cliente : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var user = context.HttpContext.Session.GetString("Rol");

            if (user != "Cliente")
            {
                context.Result = new RedirectToActionResult("Login", "Usuario", null);
            }
        }
    }
}