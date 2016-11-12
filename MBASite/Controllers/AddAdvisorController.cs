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
            details.Role = StaticVariables.Roles.FirstOrDefault(p => p.Name.Equals("Advisor"));
            details.programId = StaticVariables.Programs.FirstOrDefault(p => p.Name.Equals(data.Concentration)).Id.ToString();
            details.RoleId = details.Role.Id;
        }

        private bool PostToApi(UCMModerator details)
        {
            string url = System.Web.Configuration.WebConfigurationManager.AppSettings["baseUrl"];
            string uri = System.Web.Configuration.WebConfigurationManager.AppSettings["addAdvisor"];
            var jsonString = new JavaScriptSerializer().Serialize(details);
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
    }
}