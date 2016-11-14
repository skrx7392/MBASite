using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MBASite.Helpers;
using MBASite.ViewModels;
using MBASite.Models;

namespace MBASite.Controllers
{
    [Authorize]
    public class EditStudentController : Controller
    {
        public EditStudentController()
        {
            var Students = new List<StudentId>();
        }

        /// <summary>
        /// /// <summary>
        /// Returns a view to select a particular student from a dropdown
        /// </summary>
        /// <returns></returns>
        public ActionResult StudentsList()
        {
            List<UCMStudent> Students = new List<UCMStudent>();
            if(StaticVariables.Role.Equals("Director"))
            {
                Students = StaticVariables.StudentDetails;
            }
            else
            {
                Students = StaticVariables.StudentDetails.Where(p => p.Advisor == Convert.ToInt32(User.Identity.Name)).ToList();
            }
            return View(Students);
        }

        /// <summary>
        /// Receives value of selected student from form
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult StudentList(StudentId studentId)
        {
            TempData["student"] = studentId.Id;
            return RedirectToAction("EditStudentDetails", "EditStudentDetails");
        }
    }
}