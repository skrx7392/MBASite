using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MBASite.Helpers;
using MBASite.ViewModels;

namespace MBASite.Controllers
{
    [Authorize]
    public class EditStudentController : Controller
    {
        List<StudentId> Students;

        public EditStudentController()
        {
            Students = new List<StudentId>();
        }
        // GET: EditStudent
        public ActionResult StudentsList()
        {
            foreach (var student in StaticVariables.StudentDetails)
            {
                var id = new StudentId();
                id.Id = student.Id;
                Students.Add(id);
            }
            
            return View(Students);
        }
    }
}