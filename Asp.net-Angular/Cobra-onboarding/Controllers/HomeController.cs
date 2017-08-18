
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cobra_onboarding.Controllers
{
    public class HomeController : Controller
    {
        private Cobra db = new Cobra();
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult Person()
        {
            var emp = db.People.Select(p => new { p.Name, p.Address1, p.Address2, p.City }).ToList();
            return Json(emp, JsonRequestBehavior.AllowGet);
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