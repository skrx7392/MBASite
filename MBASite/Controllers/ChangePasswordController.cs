using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MBASite.ViewModels;
using MBASite.Helpers;

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

            }
            return View();
        }
    }
}