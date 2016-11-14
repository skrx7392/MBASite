using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MBASite.Models;
using System.Net.Http;
using Newtonsoft.Json;
using MBASite.Helpers;
using MBASite.ViewModels;

namespace MBASite.Controllers
{
    [Authorize]
    public class ViewStudentDetailsController : Controller
    {
        /// <summary>
        /// Returns the details of a particular student
        /// </summary>
        /// <returns></returns>
        public ActionResult ViewStudentDetails()
        {
            var student = StaticVariables.StudentDetails.FirstOrDefault(p => p.Id == Convert.ToInt32(User.Identity.Name));
            return View(student);
        }
    }
}