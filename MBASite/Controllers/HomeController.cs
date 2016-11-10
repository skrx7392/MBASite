using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MBASite.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

        // GET: Home
        public ActionResult Student()
        {
            return View();
        }

        public ActionResult Advisor()
        {
            return View();
        }

        public ActionResult Director()
        {
            return View();
        }
    }
}