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

        [HttpPost]
        public ActionResult StudentList(StudentId studentId)
        {
            StudentData studentData = populateData(studentId);
            TempData["studentData"] = new StudentData();
            return RedirectToAction("EditStudentDetails", "EditStudentDetails");
        }

        public StudentData populateData(StudentId studentId)
        {
            StudentData studentData = new ViewModels.StudentData();
            StudentDetails studentDetails = StaticVariables.StudentDetails.FirstOrDefault(p => p.Id == studentId.Id);
            studentData.Id = studentDetails.Id;
            studentData.Address = studentDetails.Address;
            studentData.Comments = studentDetails.Comments;
            studentData.Concentration = StaticVariables.Programs.FirstOrDefault(p => p.Id == studentDetails.ProgramId).Name;
            studentData.FirstName = studentDetails.FirstName;
            studentData.GMATScore = studentDetails.GMATScore.HasValue ? studentDetails.GMATScore.Value : 0;
            studentData.GPA = studentDetails.GPA.HasValue ? studentDetails.GPA.Value : 0;
            studentData.GREScore = studentDetails.GREScore.HasValue ? studentDetails.GREScore.Value : 0;
            studentData.LastName = studentDetails.LastName;
            studentData.NonUCMOEmailId = studentDetails.AlternateEmail;
            studentData.PhoneNumber = studentDetails.PhoneNumber;
            studentData.ProgramEntryDate = studentDetails.CreatedDate;
            studentData.UCMOEmailId = studentDetails.Email;
            return studentData;
        }
    }
}