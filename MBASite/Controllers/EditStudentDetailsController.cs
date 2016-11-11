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
        
        UCMStudent Student;
        StudentData StudentData;
        // GET: EditStudentDetails
        public ActionResult EditStudentDetails()
        {
            int studentId = 0;
            if((StaticVariables.Role.Equals("Advisor") || StaticVariables.Role.Equals("Director")) && TempData["studentData"]!=null)
            {
                if(TempData.ContainsKey("student"))
                {
                    studentId = int.Parse(TempData["student"].ToString());
                }
            }
            else if(StaticVariables.Role.Equals("Student"))
            {
                studentId = int.Parse(User.Identity.Name);
            }
            Student = StaticVariables.StudentDetails.FirstOrDefault(p => p.Id == studentId);
            StudentData = populateData(studentId);
            return View(StudentData);
        }

        [HttpPost]
        public ActionResult EditStudentDetails(StudentData studentData)
        {
            Student = StaticVariables.StudentDetails.FirstOrDefault(p => p.Id == studentData.Id);
            updateData(studentData);
            //
            //
            // To-do 
            // Update Database using Web Api
            // Update Web Api to handle edit student details
            //
            //
            return View(studentData);
        }

        public StudentData populateData(int id)
        {
            UCMStudent studentDetails = StaticVariables.StudentDetails.FirstOrDefault(p => p.Id == id);
            StudentData.Id = studentDetails.Id;
            StudentData.Address = studentDetails.Address;
            StudentData.Comments = studentDetails.Comments;
            StudentData.Concentration = StaticVariables.Programs.FirstOrDefault(p => p.Id == studentDetails.ProgramId).Name;
            StudentData.FirstName = studentDetails.FirstName;
            StudentData.GMATScore = studentDetails.GMATScore.HasValue ? studentDetails.GMATScore.Value : 0;
            StudentData.GPA = studentDetails.GPA;
            StudentData.GREScore = studentDetails.GREScore.HasValue ? studentDetails.GREScore.Value : 0;
            StudentData.LastName = studentDetails.LastName;
            StudentData.NonUCMOEmailId = studentDetails.AlternateEmail;
            StudentData.PhoneNumber = studentDetails.PhoneNumber;
            StudentData.ProgramEntryDate = studentDetails.CreatedDate;
            StudentData.UCMOEmailId = studentDetails.Email;
            return StudentData;
        }
        
        public void updateData(StudentData studentData)
        {
            Student.Address = studentData.Address;
            Student.Comments = studentData.Comments;
            Student.ProgramId = StaticVariables.Programs.FirstOrDefault(p => p.Name.Equals(studentData.Concentration)).Id;
            Student.FirstName = studentData.FirstName;
            Student.GMATScore = studentData.GMATScore;
            Student.GPA = studentData.GPA;
            Student.GREScore = studentData.GREScore;
            Student.LastName = studentData.LastName;
            Student.Email = studentData.NonUCMOEmailId;
            Student.PhoneNumber = studentData.PhoneNumber;
            Student.CreatedDate = studentData.ProgramEntryDate;
            Student.Email = studentData.UCMOEmailId;
            StaticVariables.StudentDetails.RemoveAll(x => x.Id == Student.Id);
            StaticVariables.StudentDetails.Add(Student);

        }
    }
}