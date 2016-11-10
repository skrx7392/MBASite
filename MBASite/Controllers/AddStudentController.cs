using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MBASite.ViewModels;
using MBASite.Models;
using MBASite.Helpers;
using System.Web.Security;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using System.Text;

namespace MBASite.Controllers
{
    [Authorize]
    public class AddStudentController : Controller
    {
        StudentData studentData;
        // GET: AddStudent
        public ActionResult AddStudent()
        {
            studentData = new StudentData();
            return View(studentData);
        }

        [HttpPost]
        public ActionResult AddStudent(StudentData data)
        {
            string password = PasswordGenerator.GeneratePassword();
            string md5Password = PasswordGenerator.HashPassword(password);
            UCMStudent student = new UCMStudent();
            populateUCMStudent(student, data, md5Password);
            bool postStatus = postToWebApi(student);
            if(postStatus)
            {
                return View(new StudentData());
            }
            return View(data);
        }

        private void populateUCMStudent(UCMStudent student, StudentData data, string password)
        {
            student.Address = data.Address;
            student.Advisor = null;
            student.AlternateEmail = data.NonUCMOEmailId;
            student.ApprovedGrad = false;
            student.Comments = data.Comments;
            student.CreatedDate = DateTime.Now;
            student.Email = data.UCMOEmailId;
            student.FirstName = data.FirstName;
            student.GMATScore = data.GMATScore;
            student.GPA = data.GPA;
            student.GREScore = data.GREScore;
            student.LastName = data.LastName;
            student.ModifiedDate = DateTime.Now;
            student.Password = password;
            student.PhoneNumber = data.PhoneNumber;
            student.PrereqsMet = true;
            student.Program = StaticVariables.Programs.FirstOrDefault(p => p.Name.Equals(data.Concentration));
            student.ProgramId = student.Program.Id;
            student.Role = StaticVariables.Roles.FirstOrDefault(p => p.Name.Equals(StaticVariables.Role));
            student.RoleId = student.Role.Id;
            student.StartDate = DateTime.Parse(data.ProgramEntryDate);
            student.Student_TrainingStatus = StaticVariables.TrainingStatuses.FirstOrDefault(p => p.TrainingStatus.Equals("Due"));
            student.StudentTrainingStatusId = student.Student_TrainingStatus.Id;
            student.Student_AcademicStatus = StaticVariables.AcademicStatuses.FirstOrDefault(p => p.AcademicStatus.Equals("Accepted"));
            student.Student_AcademicStatusId = student.Student_AcademicStatus.ID;
            student.Training = StaticVariables.Trainings.FirstOrDefault(p => p.Id == 1);
            student.TrainingId = student.Training.Id;
        }

        private bool postToWebApi(UCMStudent student)
        {
            StudentInfo info = new StudentInfo();
            populate(info, student);
            string url = System.Web.Configuration.WebConfigurationManager.AppSettings["baseUrl"];
            string uri = System.Web.Configuration.WebConfigurationManager.AppSettings["addStudent"];
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsJsonAsync(uri, info).Result;
                string resultString = response.Content.ReadAsStringAsync().Result;
                bool authResult = resultString.Equals("true") ? true : false;
                return authResult;
            }
            //var jsonString = Task.Run(() => JsonConvert.SerializeObject(info)).Result;
            //var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
            //using (var client = new HttpClient())
            //{
            //    var httpResponse = client.PostAsync(url + uri, httpContent).Result;
            //    if(httpResponse.Content != null)
            //    {
            //        var responseContent = httpResponse.Content.ReadAsStringAsync().Result;
            //    }
            //}
            return false;
        }

        private void populate(StudentInfo _student, UCMStudent student)
        {
            _student.Address = student.Address;
            _student.Advisor = student.Advisor;
            _student.ApprovedGrad = student.ApprovedGrad;
            _student.Comments = student.Comments;
            _student.AlternateEmail = student.AlternateEmail;
            _student.CreatedDate = student.CreatedDate;
            _student.Email = student.Email;
            _student.FirstName = student.FirstName;
            _student.GMATScore = student.GMATScore;
            _student.GPA = student.GPA;
            _student.GREScore = student.GREScore;
            _student.LastName = student.LastName;
            _student.ModifiedDate = student.ModifiedDate;
            _student.Password = student.Password;
            _student.PhoneNumber = student.PhoneNumber;
            _student.PrereqsMet = student.PrereqsMet;
            _student.ProgramId = student.ProgramId;
            _student.RoleId = student.RoleId;
            _student.StartDate = student.StartDate;
            _student.StudentTrainingStatusId = student.StudentTrainingStatusId;
            _student.Student_AcademicStatusId = student.Student_AcademicStatusId;
            _student.TrainingId = student.TrainingId;
        }
    }
}