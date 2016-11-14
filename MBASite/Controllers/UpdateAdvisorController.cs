using MBASite.Helpers;
using MBASite.Models;
using MBASite.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace MBASite.Controllers
{
    [Authorize]
    public class UpdateAdvisorController : Controller
    {
        /// <summary>
        /// Returns a list of advisors in dropdown box
        /// </summary>
        /// <returns></returns>
        public ActionResult UpdateAdvisor()
        {
            return View(StaticVariables.AdvisorDetails);
        }

        /// <summary>
        /// Returns the selected advisor from dropdown list to update advisor data
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UpdateAdvisor(StudentId id)
        {
            UCMModerator advisor = StaticVariables.AdvisorDetails.FirstOrDefault(p => p.Id == id.Id);
            AdvisorData data = new AdvisorData();
            populateData(data, advisor);
            TempData["advisor"] = data;
            return RedirectToAction("UpdateAdvisorData");
        }

        /// <summary>
        /// Copies data from model to viewmodel
        /// </summary>
        /// <param name="data"></param>
        /// <param name="advisor"></param>
        private void populateData(AdvisorData data, UCMModerator advisor)
        {
            data.AdvisorId = advisor.Id;
            data.Concentration = StaticVariables.Programs.FirstOrDefault(p => p.Id == int.Parse(advisor.programId)).Name;
            data.Email = advisor.Email;
            data.FirstName = advisor.FirstName;
            data.LastName = advisor.LastName;
            data.Status = advisor.IsActive;
        }

        /// <summary>
        /// Returns a view to update the details of selected advisor
        /// </summary>
        /// <param name="id">Id of advisor</param>
        /// <returns></returns>
        public ActionResult UpdateAdvisorData(int id)
        {
            UCMModerator advisor = StaticVariables.AdvisorDetails.FirstOrDefault(p => p.Id == id);
            //AdvisorData data = (AdvisorData)(TempData["advisor"]);
            AdvisorData data = new AdvisorData();
            populateData(data, advisor);
            return View(data);
        }

        /// <summary>
        /// Receives form data od updated advisor details
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UpdateAdvisorData(AdvisorData data)
        {
            var details = StaticVariables.AdvisorDetails.FirstOrDefault(p => p.Id == data.AdvisorId);
            UpdateAdvisorDetails(details, data);
            bool status = ContactApi.PostToApi<UCMModerator>(details, "updateAdvisor");
            if(status)
            {
                return RedirectToAction("UpdateAdvisor");
            }
            return View(data);
        }
        
        /// <summary>
        /// Copies viewmodel data to model for posting to web api
        /// </summary>
        /// <param name="details"></param>
        /// <param name="data"></param>
        private void UpdateAdvisorDetails(UCMModerator details, AdvisorData data)
        {
            details.programId = StaticVariables.Programs.FirstOrDefault(p=>p.Name.Equals(data.Concentration)).Id.ToString();
            details.Email = data.Email;
            details.FirstName = data.FirstName;
            details.LastName = data.LastName;
            details.IsActive =  data.Status;
        }

        public ActionResult CreatePassword(int id)
        {
            UCMUser user = StaticVariables.AdvisorDetails.FirstOrDefault(p => p.Id == id);
            string password = PasswordGenerator.GeneratePassword();
            string md5Password = PasswordGenerator.HashPassword(password);
            user.Password = md5Password;
            bool status = ContactApi.PostToApi(user, "updateUser");
            ViewBag.Status = status;
            return View();
        }
    }
}