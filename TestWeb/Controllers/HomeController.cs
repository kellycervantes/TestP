using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RechargeSim()
        {
            return View();
        }

        public ActionResult RechargeConfig()
        {
            return View();
        }
        public ActionResult Sims()
        {
            return View();
        }

        public ActionResult Historial()
        {
            return View();
        }

        public ActionResult Tracking()
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
    }
}