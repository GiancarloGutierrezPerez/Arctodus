using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Arctodus.Utilidades;
using Arctodus.Models;
using Arctodus.Models.Viewmodel;

namespace Arctodus.Controllers
{
    public class AccesoController : Controller
    {

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ValidarLogin(string User, string Pass)
        {
            try
            {
                using (dbArctodus_v2Entities db = new dbArctodus_v2Entities())
                {
                    var enc_pass = Encrypt.GetSHA256(Pass);

                    var lst = (from u in db.usuario
                               where u.usuario1 == User && u.password == enc_pass
                               select new UserViewModel
                               {
                                   usuario1 = u.usuario1,
                                   nombre = u.nombre
                               });

                    if (lst.Count() > 0)
                    {
                        UserViewModel ousuario = lst.First();
                        Session["User"] = ousuario;

                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return RedirectToAction("Login", "Acceso");

                    }
                }
            }
            catch (Exception ex)
            {
                return View();
            }
        }



    }
}