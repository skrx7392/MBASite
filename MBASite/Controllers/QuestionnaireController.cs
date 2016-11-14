using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MBASite.ViewModels;

namespace MBASite.Controllers
{
    [Authorize]
    public class QuestionnaireController : Controller
    {
        QuestionnaireQuestions questions;
        QuestionnaireAnswers answers;
        
        /// <summary>
        /// Returns a view which allows the student to fill questionnaire
        /// </summary>
        /// <returns></returns>
        public ActionResult FillQuestionnaire()
        {
            return View();
        }

        /// <summary>
        /// Receives filled questionnaire from form
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult FillQuestionnaire(int id)
        {
            // TO-DO
            // Create a model for questionnaire
            // Add [Serializable] attribute to model
            // follow this link : http://stackoverflow.com/questions/16352879/write-list-of-objects-to-a-file
            return RedirectToAction("Student", "Home");
        }
    }
}