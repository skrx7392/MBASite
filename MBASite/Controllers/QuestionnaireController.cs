using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MBASite.ViewModels;
using System.IO;
using Newtonsoft.Json;
using System.Net.Http;

namespace MBASite.Controllers
{
    [Authorize]
    public class QuestionnaireController : Controller
    {
        /// <summary>
        /// Returns a view which allows the student to fill questionnaire
        /// </summary>
        /// <returns></returns>
        public ActionResult FillQuestionnaire()
        {
            QuestionnaireAnswers questionnaire = new QuestionnaireAnswers();
            return View(questionnaire);
        }

        /// <summary>
        /// Receives filled questionnaire from form
        /// </summary>
        /// <param name="answers"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult FillQuestionnaire(QuestionnaireAnswers answers)
        {
            var contents = JsonConvert.SerializeObject(answers);
            string url = System.Web.Configuration.WebConfigurationManager.AppSettings["baseUrl"];
            string uri = System.Web.Configuration.WebConfigurationManager.AppSettings["login"];
            bool result;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsJsonAsync(uri, contents).Result;
                string resultString = response.Content.ReadAsStringAsync().Result;
                result = String.Equals(resultString, "true") ? true : false;
            }
            if(result)
            {
                return RedirectToAction("Student", "Home");
            }
            return View(answers);
        }
    }
}