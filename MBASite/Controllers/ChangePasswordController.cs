using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MBASite.ViewModels;
using MBASite.Helpers;
using MBASite.Models;
using System.Web.Script.Serialization;
using System.Net.Http;
using System.Text;

namespace MBASite.Controllers
{
    public class ChangePasswordController : Controller
    {
        ChangePassword changePassword;

        [Authorize]
        // GET: ChangePassword
        public ActionResult ChangePassword()
        {
            changePassword = new ChangePassword();
            return View(changePassword);
        }

        [HttpPost]
        public ActionResult ChangePassword(ChangePassword newPassword)
        {
            string oldPwd = PasswordGenerator.HashPassword(newPassword.OldPassword);
            if(StaticVariables.Role.Equals("Student"))
            {
                UCMStudent student = StaticVariables.StudentDetails.FirstOrDefault(p => p.Id == int.Parse(User.Identity.Name));
                if(oldPwd.Equals(student.Password))
                {
                    student.Password = newPassword.NewPassword;
                    postToWebApi(student);
                }
            }
            return View();
        }

        private bool postToWebApi(UCMStudent student)
        {
            string url = System.Web.Configuration.WebConfigurationManager.AppSettings["baseUrl"];
            string uri = System.Web.Configuration.WebConfigurationManager.AppSettings["updateStudent"];
            var jsonString = new JavaScriptSerializer().Serialize(student);
            var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
            using (var client = new HttpClient())
            {
                var httpResponse = client.PostAsync(url + uri, httpContent).Result;
                if (httpResponse.Content != null)
                {
                    var responseContent = httpResponse.Content.ReadAsStringAsync().Result;
                    return responseContent.Equals("\"Success\"") ? true : false;
                }
            }
            return false;
        }
    }
}