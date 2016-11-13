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
    public class EditConcentrationController : Controller
    {

        public ActionResult EditConcentrationList()
        {
            return View(StaticVariables.Programs);
        }

        [HttpPost]
        public ActionResult EditConcentrationList(Program program)
        {
            ViewProgram viewProgram = new ViewProgram();
            updateViewModel(program, viewProgram);
            TempData["program"] = viewProgram;
            return RedirectToAction("EditConcentration");
        }

        private void updateViewModel(Program program, ViewProgram viewProgram)
        {
            viewProgram.ConcentrationCode = program.Conc_Code;
            viewProgram.ConcentrationName = program.Name;
            viewProgram.Id = program.Id;
            viewProgram.IsActive = program.IsActive.Value;
            viewProgram.MajorId = program.MajorId;
        }

        // GET: EditConcentration
        public ActionResult EditConcentration()
        {
            ViewProgram viewProgram = (ViewProgram)TempData["program"];
            return View(viewProgram);
        }

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