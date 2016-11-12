using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MBASite.ViewModels;
using MBASite.Models;
using MBASite.Helpers;
using System.Net.Http;
using System.Text;
using System.Web.Script.Serialization;
using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;

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
        public async Task<ActionResult> AddStudent(StudentData data)
        {
            string password = PasswordGenerator.GeneratePassword();
            string md5Password = PasswordGenerator.HashPassword(password);
            UCMStudent student = new UCMStudent();
            populateUCMStudent(student, data, md5Password);
            bool postStatus = postToWebApi(student);
            if(postStatus)
            {
                await GenerateEmail(data, password);
                data = new StudentData();
            }
            return View(data);
        }

        private async Task GenerateEmail(StudentData data, string password)
        {
            StaticVariables.StudentDetails = AsyncEmulator.EmulateAsync<UCMStudent>("getStudents");
            UCMStudent student = StaticVariables.StudentDetails.FirstOrDefault(p => p.AlternateEmail == data.NonUCMOEmailId);
            data.Id = student.Id;
            MailMessage mail = new MailMessage();
            mail.To.Add(new MailAddress(student.AlternateEmail));
            mail.From = new MailAddress("MbaStudentucm@gmail.com");
            mail.Subject = "Congratulations";
            mail.IsBodyHtml = false;
            mail.Body = EmailBody(data, password);
            using (var client = new SmtpClient())
            {
                client.Port = 587;
                client.Credentials = new NetworkCredential
                {
                    UserName = "MbaStudentucm@gmail.com",
                    Password = "student@123"
                };
                client.EnableSsl = true;
                client.Host = "smtp.gmail.com";
                await client.SendMailAsync(mail);
            }
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
            student.Role = StaticVariables.Roles.FirstOrDefault(p => p.Name.ToLower().Equals("student"));
            student.RoleId = student.Role.Id;
            student.StartDate = data.ProgramEntryDate;
            student.Student_TrainingStatus = StaticVariables.TrainingStatuses.FirstOrDefault(p => p.TrainingStatus.Equals("Due"));
            student.StudentTrainingStatusId = student.Student_TrainingStatus.Id;
            student.Student_AcademicStatus = StaticVariables.AcademicStatuses.FirstOrDefault(p => p.AcademicStatus.Equals("Accepted"));
            student.Student_AcademicStatusId = student.Student_AcademicStatus.ID;
            student.Training = StaticVariables.Trainings.FirstOrDefault(p => p.Id == 1);
            student.TrainingId = student.Training.Id;
        }

        private bool postToWebApi(UCMStudent student)
        {
            string url = System.Web.Configuration.WebConfigurationManager.AppSettings["baseUrl"];
            string uri = System.Web.Configuration.WebConfigurationManager.AppSettings["addStudent"];
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

        private string EmailBody(StudentData data, string password)
        {
            string url = "http://localhost:18920/";
            string res = "Dear " + data.FirstName + " " + data.LastName + ",\n \nWe are glad you have been accepted into the MBA Program - " + data.Concentration + " Concentration at the University of Central Missouri and are looking forward to your participation in the program.\n \nYour next step is to access the web site linked below and answer questions which will \nenable your advisor to better serve you. This information is shared between and MBA Program Director and the Program Advisors. \nIt is not made available to outside parties.\n \nEven if your plans change and you decide not to attend, we ask that you indicate such at \nthe web site.\n \nURL:" + url +"\nStudent ID:" + data.Id + "\nPassword: " + password + "\nQuestions about the questionnaire or the MBA program should be directed to Dr. Kerry \nHenson, MBA Program Director at \n\nMBA@UCMO.EDU \n \nPlease do not reply to this message.\n\n Thanks! \n\nKerry Henson, PhD \nAssistant Dean \nMBA Program Director \nHarmon College of Business and Professional Studies \nUniversity of Central Missouri \nDockery 300C \nWarrensburg, Missouri 64093\n\n660-422-2705 \nmba@ucmo.edu";
            return res;
        }
    }
}