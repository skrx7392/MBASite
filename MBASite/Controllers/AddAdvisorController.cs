using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MBASite.Models;
using MBASite.ViewModels;
using MBASite.Helpers;

namespace MBASite.Controllers
{
    public class AddAdvisorController : Controller
    {
        AdvisorData advisorData;
        // GET: AddAdvisor
        public ActionResult AddAdvisor()
        {
            return View(new AdvisorData());
        }

        [HttpPost]
        public ActionResult AddAdvisor(AdvisorData advisorData)
        {
            UCMModerator details = new UCMModerator();
            // update and post to web api
            return View(new AdvisorData());
        }
    }
}