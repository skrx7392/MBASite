using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MBASite.Models;
using MBASite.ViewModels;
using MBASite.Helpers;

namespace MBASite.Controllers
{
    public class AddAdvisorController : Controller
    {
        AdvisorData advisorData;
        // GET: AddAdvisor
        public ActionResult AddAdvisor()
        {
            advisorData = new AdvisorData();
            return View(advisorData);
        }

        [HttpPost]
        public ActionResult AddAdvisor(AdvisorData advisorData)
        {
            UCMModerator details = new UCMModerator();
            populateAdvisorDetails(details, advisorData);
            bool added = PostToApi(details);
            if(added)
            {
                StaticVariables.AdvisorDetails.Add(details);
                return View(new AdvisorData());
            }
            return View(details);
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
            details.Role = StaticVariables.Roles.FirstOrDefault(p => p.Name.Equals("Advisor"));
            details.programId = StaticVariables.Programs.FirstOrDefault(p => p.Name.Equals(data.Concentration)).Id.ToString();
            details.RoleId = details.Role.Id;
        }

        private bool PostToApi(UCMModerator details)
        {
            // TO-DO
            return false;
        }
    }
}