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
    public class AddCourseController : Controller
    {
        // GET: AddCourse
        public ActionResult AddCourse()
        {
            ViewModels.CourseInfo course = new ViewModels.CourseInfo();
            return View(course);
        }

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

        private void populateCourse(Models.Course modelCourse, ViewModels.CourseInfo course)
        {
            modelCourse.CCode = course.ConcentrationCode;
            modelCourse.CourseNumber = course.CourseNumber.ToString();
            modelCourse.Name = course.CourseName;
            modelCourse.PreqId = string.Empty;
        } 
    }
}