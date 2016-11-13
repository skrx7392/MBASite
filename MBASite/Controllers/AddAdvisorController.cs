using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MBASite.Models;
using MBASite.ViewModels;
using MBASite.Helpers;
using System.Web.Script.Serialization;
using System.Net.Http;
using System.Text;

namespace MBASite.Controllers
{
    public class AddAdvisorController : Controller
    {
        // GET: AddAdvisor
        public ActionResult AddAdvisor()
        {
            var advisorData = new AdvisorData();
            return View(advisorData);
        }

        [HttpPost]
        public ActionResult AddAdvisor(AdvisorData advisorData)
        {
            UCMModerator details = new UCMModerator();
            populateAdvisorDetails(details, advisorData);
            bool added = ContactApi.PostToApi<UCMModerator>(details, "addAdvisor");
            if(added)
            {
                StaticVariables.AdvisorDetails.Add(details);
                return View(new AdvisorData());
            }
            return View(advisorData);
        }

        private void populateAdvisorDetails(UCMModerator details, AdvisorData data)
        {
            details.AlternateEmail = string.Empty;
            details.CreatedDate = DateTime.Now;
            details.Email = data.Email;
            details.FirstName = data.FirstName;
            details.IsActive = true;
            details.LastName = data.LastName;
            details.ModifiedDate = DateTime.Now;
            details.Password = PasswordGenerator.HashPassword(PasswordGenerator.GeneratePassword());
            details.Role = null;
            details.programId = StaticVariables.Programs.FirstOrDefault(p => p.Name.Equals(data.Concentration)).Id.ToString();
            details.RoleId = StaticVariables.Roles.FirstOrDefault(p => p.Name.Equals("Advisor")).Id;
        }
    }
}