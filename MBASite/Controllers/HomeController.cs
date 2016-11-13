using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MBASite.Helpers;
using MBASite.Models;

namespace MBASite.Controllers
{
    public class HomeController : Controller
    {

        // GET: Home
        public ActionResult Student()
        {
            StaticVariables.StudentDetails = AsyncEmulator.EmulateAsync<UCMStudent>("getStudents");
            StaticVariables.Roles = AsyncEmulator.EmulateAsync<Role>("getRoles");
            StaticVariables.TrainingStatuses = AsyncEmulator.EmulateAsync<Student_TrainingStatus>("getStudentTrainingStatus");
            StaticVariables.Trainings = AsyncEmulator.EmulateAsync<Training>("getTrainingRepo");
            StaticVariables.AcademicStatuses = AsyncEmulator.EmulateAsync<Student_AcademicStatus>("getStudentAcademicStatus");
           // ViewBag.Title = StaticVariables.StudentDetails.FirstOrDefault(p => p.Id == int.Parse(User.Identity.Name)).FirstName;
            //UCMStudent student = StaticVariables.StudentDetails.FirstOrDefault(p => p.Id == int.Parse(User.Identity.Name));
            //if (StaticVariables.TrainingStatuses.FirstOrDefault(p => p.Id == student.Id).TrainingStatus.ToLower().Equals("Due".ToLower()))
            //{
            //    return RedirectToAction("FillQuestionnaire", "Questionnaire");
            //}
            return View();
        }

        public ActionResult Advisor()
        {
            StaticVariables.StudentDetails = AsyncEmulator.EmulateAsync<UCMStudent>("getStudents");
            StaticVariables.AdvisorDetails = AsyncEmulator.EmulateAsync<UCMModerator>("getAdvisors");
            StaticVariables.Programs = AsyncEmulator.EmulateAsync<Program>("getPrograms");
            StaticVariables.Courses = AsyncEmulator.EmulateAsync<Models.Course>("getCourses");
            StaticVariables.Roles = AsyncEmulator.EmulateAsync<Role>("getRoles");
            StaticVariables.TrainingStatuses = AsyncEmulator.EmulateAsync<Student_TrainingStatus>("getStudentTrainingStatus");
            StaticVariables.Trainings = AsyncEmulator.EmulateAsync<Training>("getTrainingRepo");
            StaticVariables.AcademicStatuses = AsyncEmulator.EmulateAsync<Student_AcademicStatus>("getStudentAcademicStatus");
            //ViewBag.Title = StaticVariables.AdvisorDetails.FirstOrDefault(p => p.Id == int.Parse(User.Identity.Name)).FirstName;
            return View();
        }

        public ActionResult Director()
        {
            StaticVariables.StudentDetails = AsyncEmulator.EmulateAsync<UCMStudent>("getStudents");
            StaticVariables.AdvisorDetails = AsyncEmulator.EmulateAsync<UCMModerator>("getAdvisors");
            StaticVariables.Programs = AsyncEmulator.EmulateAsync<Program>("getPrograms");
            StaticVariables.Courses = AsyncEmulator.EmulateAsync<Models.Course>("getCourses");
            StaticVariables.Roles = AsyncEmulator.EmulateAsync<Role>("getRoles");
            StaticVariables.TrainingStatuses = AsyncEmulator.EmulateAsync<Student_TrainingStatus>("getStudentTrainingStatus");
            StaticVariables.Trainings = AsyncEmulator.EmulateAsync<Training>("getTrainingRepo");
            StaticVariables.AcademicStatuses = AsyncEmulator.EmulateAsync<Student_AcademicStatus>("getStudentAcademicStatus");
            //ViewBag.Title = "Mr. Director";
            return View();
        }
    }
}