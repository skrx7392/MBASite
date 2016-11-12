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
        // GET: UpdateAdvisor
        public ActionResult UpdateAdvisor()
        {
            List<StudentId> advisors = new List<StudentId>();
            foreach (var advisor in StaticVariables.AdvisorDetails)
            {
                advisors.Add(new StudentId() { Id = advisor.Id });
            }
            return View(advisors);
        }

        [HttpPost]
        public ActionResult UpdateAdvisor(StudentId id)
        {
            UCMModerator advisor = StaticVariables.AdvisorDetails.FirstOrDefault(p => p.Id == id.Id);
            AdvisorData data = new AdvisorData();
            populateData(data, advisor);
            TempData["advisor"] = data;
            return RedirectToAction("UpdateAdvisorData");
        }

        private void populateData(AdvisorData data, UCMModerator advisor)
        {
            data.AdvisorId = advisor.Id;
            data.Concentration = StaticVariables.Programs.FirstOrDefault(p => p.Id == int.Parse(advisor.programId)).Name;
            data.Email = advisor.Email;
            data.FirstName = advisor.FirstName;
            data.LastName = advisor.LastName;
            data.Status = advisor.IsActive;
        }

        public ActionResult UpdateAdvisorData()
        {
            AdvisorData data = (AdvisorData)(TempData["advisor"]);
            return View(data);
        }

        [HttpPost]
        public ActionResult UpdateAdvisorData(AdvisorData data)
        {
            var details = StaticVariables.AdvisorDetails.FirstOrDefault(p => p.Id == data.AdvisorId);
            UpdateAdvisorDetails(details, data);
            bool status = PostToWebApi(details);
            if(status)
            {
                return RedirectToAction("UpdateAdvisor");
            }
            return View(data);
        }

        private bool PostToWebApi(UCMModerator details)
        {
            string url = System.Web.Configuration.WebConfigurationManager.AppSettings["baseUrl"];
            string uri = System.Web.Configuration.WebConfigurationManager.AppSettings["updateAdvisor"];
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

        private void UpdateAdvisorDetails(UCMModerator details, AdvisorData data)
        {
            details.programId = StaticVariables.Programs.FirstOrDefault(p=>p.Name.Equals(data.Concentration)).Id.ToString();
            details.Email = data.Email;
            details.FirstName = data.FirstName;
            details.LastName = data.LastName;
            details.IsActive =  data.Status;
        }
    }
}