using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MVC.Filters
{
    public class Administrador : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var user = context.HttpContext.Session.GetString("Rol");

            if (user != "Administrador")
            {
                context.Result = new RedirectToActionResult("Login", "Usuario", null);
            }
        }
    }
}