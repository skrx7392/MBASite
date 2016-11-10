using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MBASite.ViewModels;

namespace MBASite.Controllers
{
    public class EditStudentAdvisingController : Controller
    {
        StudentAdvisingData studentData;
        // GET: EditStudentAdvising
        public ActionResult EditStudentAdvising()
        {
            studentData = new StudentAdvisingData();
            // TO-DO
            return View(studentData);
        }

        [HttpPost]
        public ActionResult EditStudentAdvising(StudentAdvisingData data)
        {
            //TO-DO
            return View(new StudentAdvisingData());
        }
    }
}