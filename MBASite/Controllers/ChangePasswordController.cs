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
            UCMUser user = new UCMUser();
            if(StaticVariables.Role.Equals("Student"))
            {
                userCategory = "Student";
                user = StaticVariables.StudentDetails.FirstOrDefault(p => p.Id == int.Parse(User.Identity.Name));
            }
            else
            {
                int id = StaticVariables.Role.Equals("Director") ? Convert.ToInt32(TempData["changePasswordId"]) : Convert.ToInt32(User.Identity.Name);
                userCategory = StaticVariables.Role.Equals("Director") ? "Director" : "Advisor";
                user = StaticVariables.AdvisorDetails.FirstOrDefault(p => p.Id == id);
            }
            if (oldPwd.Equals(user.Password))
            {
                user.Password = newPassword.NewPassword;
                updateStatus = ContactApi.PostToApi<UCMUser>(user, "updateUser");
                if (updateStatus)
                {
                    return RedirectToAction(userCategory, "Home");
                }
            }
            return View(newPassword);
        }
    }
}