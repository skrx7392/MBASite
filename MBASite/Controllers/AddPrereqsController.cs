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
    [Authorize]
    public class AddPrereqsController : Controller
    {
        /// <summary>
        /// Returns a new view to update course page with prereq
        /// </summary>
        /// <returns></returns>
        public ActionResult AddPrereqs()
        {
            //TO-DO
            return View();
        }

        /// <summary>
        /// Receives the form data to update course prereq
        /// </summary>
        /// <param name="prereqCourses"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddPrereqs(PrerequisiteCourses prereqCourses)
        {
            //TO-DO
            return View(new PrerequisiteCourses());
        }

        /// <summary>
        /// Returns View with list of Courses to choose from drop down
        /// </summary>
        /// <returns></returns>
        public ActionResult GetCourse()
        {
            StaticVariables.Courses = ContactApi.GetDataFromApi<Models.Course>("getCourses");
            return View(StaticVariables.Courses);
        }

        /// <summary>
        /// Receives form data of selected course
        /// </summary>
        /// <param name="courseInfo"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetCourses(Models.Course courseInfo)
        {
            return View();
        }
    }
}