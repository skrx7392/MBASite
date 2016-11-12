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
    public class EditStudentDetailsController : Controller
    {
        int studentId;
        // GET: EditStudentDetails
        public ActionResult EditStudentDetails()
        {
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
            var Student = StaticVariables.StudentDetails.FirstOrDefault(p => p.Id == studentId);
            var StudentData = populateData(studentId);
            return View(StudentData);
        }

        [HttpPost]
        public ActionResult EditStudentDetails(StudentData studentData)
        {
            var Student = updateData(studentData);
            bool status = postToWebApi(Student);
            if(status)
            {
                studentData = new StudentData();
            }
            return View(studentData);
        }

        private bool postToWebApi(UCMStudent student)
        {
            string url = System.Web.Configuration.WebConfigurationManager.AppSettings["baseUrl"];
            string uri = System.Web.Configuration.WebConfigurationManager.AppSettings["updateStudent"];
            var jsonString = new JavaScriptSerializer().Serialize(student);
            var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
            using (var client = new HttpClient())
            {
                var httpResponse = client.PostAsync(url + uri, httpContent).Result;
                if (httpResponse.Content != null)
                {
                    var responseContent = httpResponse.Content.ReadAsStringAsync().Result;
                    return responseContent.Equals("\"Success\"") ? true : false;
                }
            }
            return false;
        }

        public StudentData populateData(int id)
        {
            UCMStudent studentDetails = StaticVariables.StudentDetails.FirstOrDefault(p => p.Id == id);
            var studentData = new StudentData();
            studentData.Id = studentDetails.Id;
            studentData.Address = studentDetails.Address;
            studentData.Comments = studentDetails.Comments;
            studentData.Concentration = StaticVariables.Programs.FirstOrDefault(p => p.Id == studentDetails.ProgramId).Name;
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