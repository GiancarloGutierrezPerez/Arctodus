using Arctodus.Business;
using Arctodus.Business.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Arctodus.Controllers
{
    public class UsuarioController : Controller
    {
        IUsuarioBusiness _usBusiness;

        // oop principle: depend on the abstraction not on the concrete classes

        public UsuarioController(IUsuarioBusiness usBusiness)
        {
            _usBusiness = usBusiness;
        }

        // GET: Usuario
        public ActionResult Index()
        {


            ViewBag.Usuario = _usBusiness.GetUsuario(3);

            ViewBag.UsuarioList = _usBusiness.GetAllUsuario();


            //ViewBag.EmpName = _empBusiness.GetEmployeeName(254);

            //List<EmployeeDomainModel> listDomain = _empBusiness.GetAllEmployee();

            //List<EmployeeViewModel> listemployeeVM = new List<EmployeeViewModel>();

            //AutoMapper.Mapper.Map(listDomain, listemployeeVM);

            //ViewBag.EmployeeList = listemployeeVM;


            return View();
        }
    }
}