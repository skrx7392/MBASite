using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MBASite.ViewModels;
using MBASite.Helpers;
using MBASite.Models;

namespace MBASite.Controllers
{
    public class AddCourseController : Controller
    {
        // GET: AddCourse
        public ActionResult AddCourse()
        {
            ViewModels.Course course = new ViewModels.Course();
            return View(course);
        }

        [HttpPost]
        public ActionResult AddCourse(ViewModels.Course course)
        {
            Models.Course modelCourse = new Models.Course();
            populateCourse(modelCourse, course);
            bool added = postToWebApi(modelCourse);
            if(added)
            {
                StaticVariables.Courses.Add(modelCourse);
                return View(new ViewModels.Course());
            }
            return View(course);
        }

        private void populateCourse(Models.Course modelCourse, ViewModels.Course course)
        {
            modelCourse.ConcentrationCode = course.ConcentrationCode;
            modelCourse.CourseNumber = course.CourseNumber.ToString();
            modelCourse.Name = course.CourseName;
            modelCourse.PreqId = string.Empty;
            modelCourse.ProgramId = course.ProgramId;
        }

        private bool postToWebApi(Models.Course course)
        {
            //TO-DO
            return false;
        } 
    }
}