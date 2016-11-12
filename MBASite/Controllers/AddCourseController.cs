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
            Models.Course course = new Models.Course();
            return View(course);
        }

        [HttpPost]
        public ActionResult AddCourse(Models.Course course)
        {
            bool added = postToWebApi(course);
            if(added)
            {
                StaticVariables.Courses.Add(course);
                return View(new ViewModels.Course());
            }
            return View(course);
        }

        private void populateCourse(Models.Course modelCourse, ViewModels.Course course)
        {
            modelCourse.CCode = course.ConcentrationCode;
            modelCourse.CourseNumber = course.CourseNumber.ToString();
            modelCourse.Name = course.CourseName;
            modelCourse.PreqId = string.Empty;
        }

        private bool postToWebApi(Models.Course course)
        {
            string url = System.Web.Configuration.WebConfigurationManager.AppSettings["baseUrl"];
            string uri = System.Web.Configuration.WebConfigurationManager.AppSettings["addCourse"];
            var jsonString = new JavaScriptSerializer().Serialize(course);
            var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
            using (var client = new HttpClient())
            {
                var httpResponse = client.PostAsync(url + uri, httpContent).Result;
                if (httpResponse.Content != null)
                {
                    var responseContent = httpResponse.Content.ReadAsStringAsync().Result;
                    return responseContent.Equals("Success") ? true : false;
                }
            }
            return false;
        } 
    }
}