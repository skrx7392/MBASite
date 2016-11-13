using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MBASite.Helpers;
using MBASite.Models;

namespace MBASite.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

        // GET: Home
        public ActionResult Student()
        {
            StaticVariables.StudentDetails = ContactApi.GetDataFromApi<UCMStudent>("getStudents");
            StaticVariables.Roles = ContactApi.GetDataFromApi<Role>("getRoles");
            StaticVariables.TrainingStatuses = ContactApi.GetDataFromApi<Student_TrainingStatus>("getStudentTrainingStatus");
            StaticVariables.Trainings = ContactApi.GetDataFromApi<Training>("getTrainingRepo");
            StaticVariables.AcademicStatuses = ContactApi.GetDataFromApi<Student_AcademicStatus>("getStudentAcademicStatus");
            ViewBag.Title = StaticVariables.StudentDetails.FirstOrDefault(p => p.Id == int.Parse(User.Identity.Name)).FirstName;
            UCMStudent student = StaticVariables.StudentDetails.FirstOrDefault(p => p.Id == int.Parse(User.Identity.Name));
            if (StaticVariables.TrainingStatuses.FirstOrDefault(p => p.Id == student.Id).TrainingStatus.ToLower().Equals("Due".ToLower()))
            {
                return RedirectToAction("FillQuestionnaire", "Questionnaire");
            }
            return View();
        }

        public ActionResult Advisor()
        {
            StaticVariables.StudentDetails = ContactApi.GetDataFromApi<UCMStudent>("getStudents");
            StaticVariables.AdvisorDetails = ContactApi.GetDataFromApi<UCMModerator>("getAdvisors");
            StaticVariables.Programs = ContactApi.GetDataFromApi<Program>("getPrograms");
            StaticVariables.Courses = ContactApi.GetDataFromApi<Models.Course>("getCourses");
            StaticVariables.Roles = ContactApi.GetDataFromApi<Role>("getRoles");
            StaticVariables.TrainingStatuses = ContactApi.GetDataFromApi<Student_TrainingStatus>("getStudentTrainingStatus");
            StaticVariables.Trainings = ContactApi.GetDataFromApi<Training>("getTrainingRepo");
            StaticVariables.AcademicStatuses = ContactApi.GetDataFromApi<Student_AcademicStatus>("getStudentAcademicStatus");
            ViewBag.Title = StaticVariables.AdvisorDetails.FirstOrDefault(p => p.Id == int.Parse(User.Identity.Name)).FirstName;
            return View();
        }

        public ActionResult Director()
        {
            StaticVariables.StudentDetails = ContactApi.GetDataFromApi<UCMStudent>("getStudents");
            StaticVariables.AdvisorDetails = ContactApi.GetDataFromApi<UCMModerator>("getAdvisors");
            StaticVariables.Programs = ContactApi.GetDataFromApi<Program>("getPrograms");
            StaticVariables.Courses = ContactApi.GetDataFromApi<Models.Course>("getCourses");
            StaticVariables.Roles = ContactApi.GetDataFromApi<Role>("getRoles");
            StaticVariables.TrainingStatuses = ContactApi.GetDataFromApi<Student_TrainingStatus>("getStudentTrainingStatus");
            StaticVariables.Trainings = ContactApi.GetDataFromApi<Training>("getTrainingRepo");
            StaticVariables.AcademicStatuses = ContactApi.GetDataFromApi<Student_AcademicStatus>("getStudentAcademicStatus");
            ViewBag.Title = "Mr. Director";
            return View();
        }
    }
}