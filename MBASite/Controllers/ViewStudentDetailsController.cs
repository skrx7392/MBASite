using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MBASite.Models;
using System.Net.Http;
using Newtonsoft.Json;
using MBASite.Helpers;
using MBASite.ViewModels;

namespace MBASite.Controllers
{
    public class ViewStudentDetailsController : Controller
    {
        UCMStudent student;
        StudentData data;
        public ViewStudentDetailsController()
        {
            student = StaticVariables.StudentDetails.FirstOrDefault(p => p.Id == Convert.ToInt32(User.Identity.Name));
        }

        // GET: ViewStudentDetails
        public ActionResult ViewStudentDetails()
        {
            if (student.Training.Name.Equals("Due"))
                return RedirectToAction("FillQuestionnaire", "Questionnaire");
            populateStudentData();
            return View(data);
        }

        private void populateStudentData()
        {
            data = new StudentData();
            data.Address = student.Address;
            data.Comments = student.Comments;
            data.Concentration = StaticVariables.Programs.Find(p => p.Id == student.ProgramId).Name;
            data.FirstName = student.FirstName;
            data.Id = student.Id;
            data.LastName = student.LastName;
            data.NonUCMOEmailId = student.AlternateEmail;
            data.PhoneNumber = student.PhoneNumber;
            data.ProgramEntryDate = student.CreatedDate;
            data.GMATScore = student.GMATScore.Value;
            data.GREScore = student.GREScore.Value;
            data.UCMOEmailId = student.Email;
        }
    }
}