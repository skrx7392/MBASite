using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MBASite.ViewModels;
using MBASite.Models;
using MBASite.Helpers;
using System.Web.Script.Serialization;
using System.Net.Http;
using System.Text;

namespace MBASite.Controllers
{
    [Authorize]
    public class EditStudentAdvisingController : Controller
    {
        /// <summary>
        /// Returns a view to edit student advising data
        /// </summary>
        /// <param name="id">todo: describe id parameter on EditStudentAdvising</param>
        /// <returns></returns>
        public ActionResult EditStudentAdvising(int id)
        {
            var studentData = new StudentAdvisingData();
            var studentDetails = StaticVariables.StudentDetails.FirstOrDefault(p => p.Id == id);
            populateData(studentData, studentDetails);
            return View(studentData);
        }

        /// <summary>
        /// Receives the form to send to the api
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EditStudentAdvising(StudentAdvisingData data)
        {
            var studentDetails = updateStudentDetails(data);
            bool status = ContactApi.PostToApi<UCMStudent>(studentDetails, "updateStudent");
            if(status)
            {
                return View(new StudentAdvisingData());
            }
            return View(data);
        }

        /// <summary>
        /// Copies data from model to viewmodel for display
        /// </summary>
        /// <param name="studentData"></param>
        /// <param name="details"></param>
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

        /// <summary>
        /// Copies data from viewmodel to model for sending to the api
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private UCMStudent updateStudentDetails(StudentAdvisingData data)
        {
            var details = StaticVariables.StudentDetails.FirstOrDefault(p => p.Id == data.Id);
            details.Program = StaticVariables.Programs.FirstOrDefault(p => p.Name.Equals(data.Concentration));
            details.ProgramId = details.Program.Id;
            details.Advisor = Convert.ToInt32(data.Advisor);
            details.ApprovedGrad = data.approvedForGraduation;
            details.Comments = data.Comments;
            details.FirstName = data.FirstName;
            details.LastName = data.LastName;
            details.Student_AcademicStatus = StaticVariables.AcademicStatuses.FirstOrDefault(p => p.AcademicStatus.Equals(data.ProgramStatus));
            return details;
        }
    }
}