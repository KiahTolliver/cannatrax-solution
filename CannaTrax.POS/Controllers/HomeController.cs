
using CannaTrax.POS.ViewModelManagers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CannaTrax.POS.Controllers
{
    public class HomeController : Controller
    {
        private IEmployeeManager _employeeManager;
        public HomeController(EmployeeManager employeeManager)
        {
            _employeeManager = employeeManager;
        }
        public HomeController():this(new EmployeeManager())
        {

        }
       
        public ActionResult Index()
        {
            var vm = _employeeManager.GetEmployeeList();
            return View(vm);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}