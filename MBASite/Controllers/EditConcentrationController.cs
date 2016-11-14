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
    public class EditConcentrationController : Controller
    {
        /// <summary>
        /// Returns a view to select concentration to edit 
        /// </summary>
        /// <returns></returns>
        public ActionResult EditConcentrationList()
        {
            return View(StaticVariables.Programs);
        }

        ///// <summary>
        ///// Retrieves the form data of selected concentration 
        ///// </summary>
        ///// <param name="program"></param>
        ///// <returns></returns>
        //[HttpPost]
        //public ActionResult EditConcentrationList(Program program)
        //{
        //    ViewProgram viewProgram = new ViewProgram();
        //    updateViewModel(program, viewProgram);
        //    TempData["program"] = viewProgram;
        //    return RedirectToAction("EditConcentration");
        //}

        /// <summary>
        /// Copies model data into viewmodel
        /// </summary>
        /// <param name="program"></param>
        /// <param name="viewProgram"></param>
        private void updateViewModel(Program program, ViewProgram viewProgram)
        {
            viewProgram.ConcentrationCode = program.Conc_Code;
            viewProgram.ConcentrationName = program.Name;
            viewProgram.Id = program.Id;
            viewProgram.IsActive = program.IsActive.HasValue ? program.IsActive.Value : false;
            viewProgram.MajorId = program.MajorId;
        }

        /// <summary>
        /// Returns a view to edit the selected concentration
        /// </summary>
        /// <param name="id">todo: describe id parameter on EditConcentration</param>
        /// <returns></returns>
        public ActionResult EditConcentration(int id)
        {
            Program program = StaticVariables.Programs.FirstOrDefault(p => p.Id == id);
            ViewProgram viewProgram = new ViewProgram();
            updateViewModel(program, viewProgram);
            return View(viewProgram);
        }
        
        /// <summary>
        /// Receives the form data of edited concentration
        /// </summary>
        /// <param name="viewProgram"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EditConcentration(ViewProgram viewProgram)
        {
            Program program = StaticVariables.Programs.FirstOrDefault(p => p.Id == viewProgram.Id);
            populateProgramDetails(program, viewProgram);
            bool status = ContactApi.PostToApi<Program>(program, "updateProgram");
            if (status)
                return RedirectToAction("EditConcentrationList");
            return View(viewProgram);
        }

        /// <summary>
        /// Copies data from viewmodel to model
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