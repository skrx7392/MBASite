using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MBASite.ViewModels;
using MBASite.Models;

namespace MBASite.Controllers
{
    public class AddStudentController : Controller
    {
        StudentData studentData;
        // GET: AddStudent
        public ActionResult AddStudent()
        {
            // TO-DO
            // Remove Id from View
            studentData = new StudentData();
            return View(studentData);
        }

        [HttpPost]
        public ActionResult AddStudent(StudentData data)
        {
            //
            // Create a new model to configure addstudent data
            return View(new StudentData());
        }
    }
}