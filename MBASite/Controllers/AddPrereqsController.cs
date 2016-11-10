using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MBASite.ViewModels;

namespace MBASite.Controllers
{
    public class AddPrereqsController : Controller
    {
        PrerequisiteCourses prereqs;
        
        // GET: AddPrereqs
        public ActionResult AddPrereqs()
        {
            //TO-DO
            return View(prereqs);
        }

        [HttpPost]
        public ActionResult AddPrereqs(PrerequisiteCourses prereqCourses)
        {
            //TO-DO
            return View(new PrerequisiteCourses());
        }
    }
}