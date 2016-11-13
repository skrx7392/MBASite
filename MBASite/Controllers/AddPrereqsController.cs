using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MBASite.ViewModels;
using MBASite.Models;
using MBASite.Helpers;

namespace MBASite.Controllers
{
    public class AddPrereqsController : Controller
    {
        // GET: AddPrereqs
        public ActionResult AddPrereqs()
        {
            //TO-DO
            return View();
        }

        [HttpPost]
        public ActionResult AddPrereqs(PrerequisiteCourses prereqCourses)
        {
            //TO-DO
            return View(new PrerequisiteCourses());
        }

        public ActionResult GetCourse()
        {
            StaticVariables.Courses = ContactApi.GetDataFromApi<Models.Course>("getCourses");
            return View(StaticVariables.Courses);
        }

        [HttpPost]
        public ActionResult GetCourses(Models.Course courseInfo)
        {
            return View();
        }
    }
}