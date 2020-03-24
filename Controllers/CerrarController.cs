using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Arctodus.Controllers
{
    public class CerrarController : Controller
    {
        // GET: Cerrar
        public ActionResult Logoff()
        {
            Session["User"] = null;
            return RedirectToAction("Login", "Acceso");
        }
    }
}