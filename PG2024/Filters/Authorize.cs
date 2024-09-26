using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PG2024.Models;

namespace PG2024.Filters
{
    public class Authorize : ActionFilterAttribute
    {
        private readonly string[] allowedRoles;

        public Authorize(params string[] roles)
        {
            this.allowedRoles = roles;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var oUser = (Usuario)HttpContext.Current.Session["User"];
            if (oUser == null)
            {
                filterContext.HttpContext.Response.Redirect("~/Access/Index");
            }
            else
            {
                using (var db = new BoutiqueMEEntities())
                {
                    var userRole = db.TipoUsuario.Find(oUser.TipoUsuarioID).Tipo;

                    if (!allowedRoles.Contains(userRole))
                    {
                        filterContext.HttpContext.Response.Redirect("~/Home/Unauthorized");
                    }
                }
            }
            base.OnActionExecuting(filterContext);
        }
    }
}
