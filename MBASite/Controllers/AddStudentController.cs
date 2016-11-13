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

        /// <summary>
        /// Returns a view to add a new student
        /// </summary>
        /// <returns></returns>
        public ActionResult AddStudent()
        {
            studentData = new StudentData();
            return View(studentData);
        }

        /// <summary>
        /// Receives the Form data of creating a new sttudent asynchronously
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> AddStudent(StudentData data)
        {
            string password = PasswordGenerator.GeneratePassword();
            string md5Password = PasswordGenerator.HashPassword(password);
            UCMStudent student = new UCMStudent();
            populateUCMStudent(student, data, md5Password);
            bool postStatus = ContactApi.PostToApi<UCMStudent>(student, "addStudent");
            if(postStatus)
            {
                await GenerateEmail(data, password);
                data = new StudentData();
            }
            return View(data);
        }

        /// <summary>
        /// Generates and sends email to the newly accepted student asynchronously
        /// </summary>
        /// <param name="data"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        private async Task GenerateEmail(StudentData data, string password)
        {
            StaticVariables.StudentDetails = ContactApi.GetDataFromApi<UCMStudent>("getStudents");
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

        /// <summary>
        /// Copies data from viewmodel to model for sending to web api
        /// </summary>
        /// <param name="student"></param>
        /// <param name="data"></param>
        /// <param name="password"></param>
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
            student.PrereqsMet = false;
            student.Program = null;
            student.ProgramId = StaticVariables.Programs.FirstOrDefault(p => p.Name.Equals(data.Concentration)).Id;
            student.Role = null;
            student.RoleId = StaticVariables.Roles.FirstOrDefault(p => p.Name.ToLower().Equals("student")).Id;
            student.StartDate = data.ProgramEntryDate;
            student.Student_TrainingStatus = null;
            student.StudentTrainingStatusId = StaticVariables.TrainingStatuses.FirstOrDefault(p => p.TrainingStatus.Equals("Due")).Id;
            student.Student_AcademicStatus = null;
            student.Student_AcademicStatusId = StaticVariables.AcademicStatuses.FirstOrDefault(p => p.AcademicStatus.Equals("Accepted")).ID;
            student.Training = null;
            student.TrainingId = StaticVariables.Trainings.FirstOrDefault(p => p.Id == 1).Id;
        }

        /// <summary>
        /// Formats the Email Body using non html
        /// </summary>
        /// <param name="data"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        private string EmailBody(StudentData data, string password)
        {
            string url = "http://localhost:18920/";
            string res = "Dear " + data.FirstName + " " + data.LastName + ",\n \nWe are glad you have been accepted into the MBA Program - " + data.Concentration + " Concentration at the University of Central Missouri and are looking forward to your participation in the program.\n \nYour next step is to access the web site linked below and answer questions which will \nenable your advisor to better serve you. This information is shared between and MBA Program Director and the Program Advisors. \nIt is not made available to outside parties.\n \nEven if your plans change and you decide not to attend, we ask that you indicate such at \nthe web site.\n \nURL:" + url +"\nStudent ID:" + data.Id + "\nPassword: " + password + "\nQuestions about the questionnaire or the MBA program should be directed to Dr. Kerry \nHenson, MBA Program Director at \n\nMBA@UCMO.EDU \n \nPlease do not reply to this message.\n\n Thanks! \n\nKerry Henson, PhD \nAssistant Dean \nMBA Program Director \nHarmon College of Business and Professional Studies \nUniversity of Central Missouri \nDockery 300C \nWarrensburg, Missouri 64093\n\n660-422-2705 \nmba@ucmo.edu";
            return res;
        }

        private Comments CreateComments(string comment)
        {
            return ConfigureComments.DeserializeComments(comment);
        }
    }
}