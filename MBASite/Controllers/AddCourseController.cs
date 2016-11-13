using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MBASite.ViewModels;
using MBASite.Helpers;
using MBASite.Models;
using System.Web.Script.Serialization;
using System.Text;
using System.Net.Http;

namespace MBASite.Controllers
{
    [Authorize]
    public class AddCourseController : Controller
    {
        /// <summary>
        /// Returns a view for creating new course
        /// </summary>
        /// <returns></returns>
        public ActionResult AddCourse()
        {
            ViewModels.CourseInfo course = new ViewModels.CourseInfo();
            return View(course);
        }

        /// <summary>
        /// Receives the form data of creating a new course
        /// </summary>
        /// <param name="course"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddCourse(ViewModels.CourseInfo course)
        {
            Models.Course courseInfo = new Models.Course();
            populateCourse(courseInfo, course);
            bool added = ContactApi.PostToApi<Course>(courseInfo, "addCourse");
            if(added)
            {
                StaticVariables.Courses.Add(courseInfo);
                return View(new ViewModels.CourseInfo());
            }
            return View(course);
        }

        /// <summary>
        /// Copies data from viewmodel to model for sending to web api
        /// </summary>
        /// <param name="modelCourse"></param>
        /// <param name="course"></param>
        private void populateCourse(Models.Course modelCourse, ViewModels.CourseInfo course)
        {
            modelCourse.CCode = course.ConcentrationCode;
            modelCourse.CourseNumber = course.CourseNumber.ToString();
            modelCourse.Name = course.CourseName;
            modelCourse.PreqId = string.Empty;
        } 
    }
}