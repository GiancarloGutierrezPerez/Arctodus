using System.Web;
using System.Web.Mvc;
using Arctodus.Controllers;
using Arctodus.Models;
using Arctodus.Models.Viewmodel;

namespace Arctodus.Filters
{
    public class VerifySession:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var oUsuario = (UserViewModel)HttpContext.Current.Session["User"];

            if (oUsuario == null)
            {
                if(filterContext.Controller is AccesoController == false)
                {
                    filterContext.HttpContext.Response.Redirect("~/Acceso/Login");
                }
            }
            else
            {
                if (filterContext.Controller is AccesoController == true)
                {
                    filterContext.HttpContext.Response.Redirect("~/Home/Index");
                }
            }

            base.OnActionExecuting(filterContext);
        }
    }
}