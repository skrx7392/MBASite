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
    [Authorize]
    public class EditStudentDetailsController : Controller
    {
        /// <summary>
        /// Returns a view to edit student details
        /// </summary>
        /// <param name="id">todo: describe id parameter on EditStudentDetails</param>
        /// <returns></returns>
        public ActionResult EditStudentDetails(int id)
        {
            var Student = StaticVariables.StudentDetails.FirstOrDefault(p => p.Id == id);
            var StudentData = populateData(id);
            return View(StudentData);
        }

        /// <summary>
        /// Receives form data of updated student details
        /// </summary>
        /// <param name="studentData"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EditStudentDetails(StudentData studentData)
        {
            var Student = updateData(studentData);
            bool status = ContactApi.PostToApi<UCMStudent>(Student, "updateStudent");
            if(status)
            {
                studentData = new StudentData();
            }
            return View(studentData);
        }

        /// <summary>
        /// Update viewmodel data from model 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public StudentData populateData(int id)
        {
            UCMStudent studentDetails = StaticVariables.StudentDetails.FirstOrDefault(p => p.Id == id);
            var studentData = new StudentData();
            studentData.Id = studentDetails.Id;
            studentData.Address = studentDetails.Address;
            studentData.Comments = studentDetails.Comments;
            studentData.Concentration = StaticVariables.Programs.FirstOrDefault(p=>p.Id==studentDetails.ProgramId).Name;
            studentData.FirstName = studentDetails.FirstName;
            studentData.GMATScore = studentDetails.GMATScore.HasValue ? studentDetails.GMATScore.Value : 0;
            studentData.GPA = studentDetails.GPA;
            studentData.GREScore = studentDetails.GREScore.HasValue ? studentDetails.GREScore.Value : 0;
            studentData.LastName = studentDetails.LastName;
            studentData.NonUCMOEmailId = studentDetails.AlternateEmail;
            studentData.PhoneNumber = studentDetails.PhoneNumber;
            studentData.ProgramEntryDate = studentDetails.CreatedDate;
            studentData.UCMOEmailId = studentDetails.Email;
            return studentData;
        }
        
        /// <summary>
        /// Update model data from viewmodel data
        /// </summary>
        /// <param name="studentData"></param>
        /// <returns></returns>
        public UCMStudent updateData(StudentData studentData)
        {
            var Student = StaticVariables.StudentDetails.FirstOrDefault(p => p.Id == studentData.Id);
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
            return Student;
        }
    }
}