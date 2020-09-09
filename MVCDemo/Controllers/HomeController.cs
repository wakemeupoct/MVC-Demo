using MVCDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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

        //// GET: Emp
        //public ActionResult Emp()
        //{
        //    return View(GetDepEmp());
        //}


        //private List<vDeptEmp> GetDepEmp()
        //{
        //    List<vDeptEmp> deptEmps = new List<vDeptEmp>();

        //    using (MVCDemoEntities db = new MVCDemoEntities())
        //    {
        //        deptEmps = db.vDeptEmp.ToList();
        //    }

        //    return deptEmps;
        //}
    }
}