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
    [Authorize]
    public class ChangePasswordController : Controller
    {
        /// <summary>
        /// Returns a view to change existing password
        /// </summary>
        /// <returns></returns>
        public ActionResult ChangePassword()
        {
            var changePassword = new ChangePassword();
            return View(changePassword);
        }

        /// <summary>
        /// Receives  the form data to update the password
        /// </summary>
        /// <param name="newPassword"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ChangePassword(ChangePassword newPassword)
        {
            string oldPwd = PasswordGenerator.HashPassword(newPassword.OldPassword);
            string userCategory = string.Empty;
            UCMUser user = new UCMUser();
            if(StaticVariables.Role.Equals("Student"))
            {
                userCategory = "Student";
                user = StaticVariables.StudentDetails.FirstOrDefault(p => p.Id == int.Parse(User.Identity.Name));
            }
            else
            {
                userCategory = "Advisor";
                user = StaticVariables.AdvisorDetails.FirstOrDefault(p => p.Id == Convert.ToInt32(User.Identity.Name));
            }
            if (oldPwd.Equals(user.Password))
            {
                user.Password = newPassword.NewPassword;
                bool updateStatus = ContactApi.PostToApi<UCMUser>(user, "updateUser");
                if (updateStatus)
                {
                    return RedirectToAction(userCategory, "Home");
                }
            }
            return View(newPassword);
        }
        
    }
}