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

        /// <summary>
        /// Redirects to home page of students, 
        /// </summary>
        /// <returns></returns>
        public ActionResult Student()
        {
            StaticVariables.StudentDetails = ContactApi.GetDataFromApi<UCMStudent>("getStudents");
            StaticVariables.Roles = ContactApi.GetDataFromApi<Role>("getRoles");
            StaticVariables.TrainingStatuses = ContactApi.GetDataFromApi<Student_TrainingStatus>("getStudentTrainingStatus");
            StaticVariables.Trainings = ContactApi.GetDataFromApi<Training>("getTrainingRepo");
            StaticVariables.AcademicStatuses = ContactApi.GetDataFromApi<Student_AcademicStatus>("getStudentAcademicStatus");
            ViewBag.Title = StaticVariables.StudentDetails.FirstOrDefault(p => p.Id == int.Parse(User.Identity.Name)).FirstName;
            UCMStudent student = StaticVariables.StudentDetails.FirstOrDefault(p => p.Id == int.Parse(User.Identity.Name));
            //FillQuestionnaire
            if (false)
            {
                return RedirectToAction("FillQuestionnaire", "Questionnaire");
            }
            if (StaticVariables.TrainingStatuses.FirstOrDefault(p => p.Id == student.StudentTrainingStatusId).TrainingStatus.ToLower().Equals("Due".ToLower()))
            {
                return RedirectToAction("AcademicCodeOfConduct");
            }
            return View();
        }

        /// <summary>
        /// Redirects to advisor home page
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Redirects to director home page
        /// </summary>
        /// <returns></returns>
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

        public ActionResult AcademicCodeOfConduct()
        {
            return View();
        }

        public ActionResult ACCCompleted()
        {
            int id = Convert.ToInt32(User.Identity.Name);
            UCMStudent student = StaticVariables.StudentDetails.FirstOrDefault(p => p.Id == id);
            student.StudentTrainingStatusId = 3;
            bool status = ContactApi.PostToApi(student, "updateStudent");
            if(status)
            {
                return RedirectToAction("Student");
            }
            return RedirectToAction("AcademicCodeOfConduct");
        }
    }
}