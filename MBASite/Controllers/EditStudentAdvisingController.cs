using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MBASite.ViewModels;
using MBASite.Models;
using MBASite.Helpers;

namespace MBASite.Controllers
{
    public class EditStudentAdvisingController : Controller
    {
        StudentAdvisingData studentData;
        UCMStudent studentDetails;
        // GET: EditStudentAdvising
        public ActionResult EditStudentAdvising()
        {
            studentData = new StudentAdvisingData();
            studentDetails = StaticVariables.StudentDetails.FirstOrDefault(p => p.Id == Convert.ToInt32(User.Identity.Name));
            populateData(studentData, studentDetails);
            return View(studentData);
        }

        [HttpPost]
        public ActionResult EditStudentAdvising(StudentAdvisingData data)
        {
            updateStudentDetails(data, studentDetails);
            //TO-DO
            //Post to Web Api
            return View(new StudentAdvisingData());
        }

        private void populateData(StudentAdvisingData studentData, UCMStudent details)
        {
            studentData.Id = details.Id;
            studentData.Concentration = StaticVariables.Programs.FirstOrDefault(p => p.Id == details.ProgramId).Name;
            studentData.Advisor = details.Advisor.ToString();
            studentData.approvedForGraduation = details.ApprovedGrad.Value;
            studentData.Comments = details.Comments;
            studentData.FirstName = details.FirstName;
            studentData.LastName = details.LastName;
            studentData.ProgramStatus = StaticVariables.AcademicStatuses.FirstOrDefault(p => p.ID == details.Student_AcademicStatusId).AcademicStatus;
        }

        private void updateStudentDetails(StudentAdvisingData data, UCMStudent details)
        {
            details.Program = StaticVariables.Programs.FirstOrDefault(p => p.Name.Equals(data.Concentration));
            details.ProgramId = details.Program.Id;
            details.Advisor = Convert.ToInt32(data.Advisor);
            details.ApprovedGrad = data.approvedForGraduation;
            details.Comments = data.Comments;
            details.FirstName = data.FirstName;
            details.LastName = data.LastName;
            details.Student_AcademicStatus = StaticVariables.AcademicStatuses.FirstOrDefault(p => p.AcademicStatus.Equals(data.ProgramStatus));
        }
    }
}