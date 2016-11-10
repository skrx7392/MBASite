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
        List<UCMStudent> studentDetails;
        List<Program> programs;
        List<StudentData> studentData;
        
        public ViewStudentDetailsController()
        {
            studentDetails = new List<UCMStudent>();
            programs = new List<Program>();
            studentData = new List<StudentData>();
            studentDetails = AsyncEmulator.EmulateAsync<UCMStudent>("getStudents");
            programs = AsyncEmulator.EmulateAsync<Program>("getPrograms");
            populateStudentData();
        }

        // GET: ViewStudentDetails
        public ActionResult ViewStudentDetails()
        {
            return View(studentData);
        }
        
        private void populateStudentData()
        {
            foreach(var details in studentDetails)
            {
                var data = new StudentData();
                data.Address = details.Address;
                data.Comments = details.Comments;
                data.Concentration = programs.Find(p=>p.Id == details.ProgramId).Name;
                data.FirstName = details.FirstName;
                data.Id = details.Id;
                data.LastName = details.LastName;
                data.NonUCMOEmailId = details.AlternateEmail;
                data.PhoneNumber = details.PhoneNumber;
                //data.ProgramEntryDate = details.CreatedDate;
                data.GMATScore = details.GMATScore.HasValue ? details.GMATScore.Value : 0;
                data.GREScore = details.GREScore.HasValue ? details.GMATScore.Value : 0;
                data.UCMOEmailId = details.Email;
                studentData.Add(data);
            }
        }
    }
}