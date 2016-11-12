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
        StudentId Students;
        int Id;

        public EditStudentController()
        {
            Students = new StudentId();
        }
        // GET: EditStudent
        public ActionResult StudentsList()
        {
            foreach (var student in StaticVariables.StudentDetails)
            {
                int identity = student.Id;
                Students.Id.Add(identity);
            }
            return View(Students);
        }

        [HttpPost]
        public ActionResult StudentList(StudentId studentId)
        {
            TempData["student"] = studentId.Id;
            return RedirectToAction("EditStudentDetails", "EditStudentDetails");
        }
    }
}