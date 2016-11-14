using MBASite.Helpers;
using MBASite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MBASite.Controllers
{
    [Authorize]
    public class TrainingDueController : Controller
    {
        // GET: TrainingDue
        public ActionResult TrainingDueStudents()
        {
            List<UCMStudent> students = StaticVariables.StudentDetails.Where(p => p.StudentTrainingStatusId == StaticVariables.TrainingStatuses.FirstOrDefault(a => a.TrainingStatus.Equals("Due")).Id).ToList();
            return View(students);
        }
    }
}