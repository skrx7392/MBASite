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
        [Authorize]
        // GET: ChangePassword
        public ActionResult ChangePassword()
        {
            var changePassword = new ChangePassword();
            return View(changePassword);
        }

        [HttpPost]
        public ActionResult ChangePassword(ChangePassword newPassword)
        {
            string oldPwd = PasswordGenerator.HashPassword(newPassword.OldPassword);
            bool updateStatus = false;
            string userCategory = string.Empty;
            if(StaticVariables.Role.Equals("Student"))
            {
                userCategory = "Student";
                UCMUser user = StaticVariables.StudentDetails.FirstOrDefault(p => p.Id == int.Parse(User.Identity.Name));
                if(oldPwd.Equals(user.Password))
                {
                    user.Password = newPassword.NewPassword;
                    updateStatus = postToWebApi(user);
                }
            }
            else
            {
                int id = StaticVariables.Role.Equals("Director") ? Convert.ToInt32(TempData["changePasswordId"]) : Convert.ToInt32(User.Identity.Name);
                userCategory = StaticVariables.Role.Equals("Director") ? "Director" : "Advisor";
                UCMUser user = StaticVariables.AdvisorDetails.FirstOrDefault(p => p.Id == id);
                if (oldPwd.Equals(user.Password))
                {
                    user.Password = newPassword.NewPassword;
                    updateStatus = postToWebApi(user);
                }
            }
            if(updateStatus)
            {
                return RedirectToAction(userCategory, "Home");
            }
            return View(newPassword);
        }

        private bool postToWebApi(UCMUser student)
        {
            string url = System.Web.Configuration.WebConfigurationManager.AppSettings["baseUrl"];
            string uri = System.Web.Configuration.WebConfigurationManager.AppSettings["updateUser"];
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