using MBASite.Helpers;
using MBASite.Models;
using MBASite.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MBASite.Controllers
{
    [Authorize]
    public class AddConcentrationController : Controller
    {
        /// <summary>
        /// Returns a view which allows the director to add a concentration
        /// </summary>
        /// <returns></returns>
        public ActionResult AddConcentration()
        {
            ViewProgram program = new ViewProgram();
            return View(program);
        }

        /// <summary>
        /// Receives the form data of add concentration
        /// </summary>
        /// <param name="viewProgram"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddConcentration(ViewProgram viewProgram)
        {
            Program program = new Program();
            populateProgramDetails(program, viewProgram);
            bool status = ContactApi.PostToApi(program, "AddProgram");
            if(status)
            {
                viewProgram = new ViewProgram();
            }
            return View(viewProgram);
        }

        /// <summary>
        /// Populates viewmodel data from model
        /// </summary>
        /// <param name="program"></param>
        /// <param name="viewProgram"></param>
        private void populateProgramDetails(Program program, ViewProgram viewProgram)
        {
            program.Conc_Code = viewProgram.ConcentrationCode;
            program.courses = new List<Course>();
            program.IsActive = viewProgram.IsActive;
            program.Major = null;
            program.MajorId = viewProgram.MajorId;
            program.Name = viewProgram.ConcentrationName;
            program.UCMStudents = new List<UCMStudent>();
        }
    }
}