using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MBASite.ViewModels;
using MBASite.Helpers;
using MBASite.Models;

namespace MBASite.Controllers
{
    public class EditStudentDetailsController : Controller
    {
        StudentData studentData;
        // GET: EditStudentDetails
        public ActionResult EditStudentDetails()
        {
            if((StaticVariables.Role.Equals("Advisor") || StaticVariables.Role.Equals("Director")) && TempData["studentData"]!=null)
            {
                return View(TempData["studentData"]);
            }
            if(StaticVariables.Role.Equals("Student"))
            {
                int id = int.Parse(User.Identity.Name);
                studentData = populateData(id);
                return View(studentData);
            }
            return View();
        }

        public StudentData populateData(int id)
        {
            UCMStudent studentDetails = StaticVariables.StudentDetails.FirstOrDefault(p => p.Id == id);
            studentData.Id = studentDetails.Id;
            studentData.Address = studentDetails.Address;
            studentData.Comments = studentDetails.Comments;
            studentData.Concentration = StaticVariables.Programs.FirstOrDefault(p => p.Id == studentDetails.ProgramId).Name;
            studentData.FirstName = studentDetails.FirstName;
            studentData.GMATScore = studentDetails.GMATScore.HasValue ? studentDetails.GMATScore.Value : 0;
            //studentData.GPA = studentDetails.GPA.HasValue ? studentDetails.GPA.Value : 0;
            studentData.GREScore = studentDetails.GREScore.HasValue ? studentDetails.GREScore.Value : 0;
            studentData.LastName = studentDetails.LastName;
            studentData.NonUCMOEmailId = studentDetails.AlternateEmail;
            studentData.PhoneNumber = studentDetails.PhoneNumber;
            //studentData.ProgramEntryDate = studentDetails.CreatedDate;
            studentData.UCMOEmailId = studentDetails.Email;
            return studentData;
        }

        [HttpPost]
        public ActionResult EditStudentDetails(StudentData studentData)
        {
            UCMStudent studentDetails = StaticVariables.StudentDetails.FirstOrDefault(p => p.Id == studentData.Id);
            studentDetails.Address = studentData.Address;
            studentDetails.Comments = studentData.Comments;
            studentDetails.ProgramId = StaticVariables.Programs.FirstOrDefault(p => p.Name.Equals(studentData.Concentration)).Id;
            studentDetails.FirstName = studentData.FirstName;
            studentDetails.GMATScore = studentData.GMATScore;
            //studentDetails.GPA = studentData.GPA;
            studentDetails.GREScore = studentData.GREScore;
            studentDetails.LastName = studentData.LastName;
            studentDetails.Email = studentData.NonUCMOEmailId;
            studentDetails.PhoneNumber = studentData.PhoneNumber;
            //studentDetails.CreatedDate = studentData.ProgramEntryDate;
            studentDetails.Email = studentData.UCMOEmailId;
            StaticVariables.StudentDetails.RemoveAll(x => x.Id == studentDetails.Id);
            StaticVariables.StudentDetails.Add(studentDetails);
            //
            //
            // To-do 
            // Update Database using Web Api
            // Update Web Api to handle edit student details
            //
            //
            return RedirectToAction("EditStudentDetails", studentData);
        }
    }
}