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
        /// <param name="id">Course Id</param>
        /// <returns></returns>
        public ActionResult AddPrereqs(int id)
        {
            Course course = StaticVariables.Courses.FirstOrDefault(p => p.Id == id);
            return View(course);
        }

        /// <summary>
        /// Receives the form data to update course prereq
        /// </summary>
        /// <param name="courseInfo"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddPrereqs(Course courseInfo)
        {
            Course course = StaticVariables.Courses.FirstOrDefault(p => p.Id == courseInfo.Id);
            course.PreqId = courseInfo.PreqId;
            course.PrereqIsActive = courseInfo.PrereqIsActive;
            bool status = ContactApi.PostToApi<Course>(course, "updateCourse");
            if(status)
            {
                return RedirectToAction("GetCourse");
            }
            return View(course);
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
    }
}