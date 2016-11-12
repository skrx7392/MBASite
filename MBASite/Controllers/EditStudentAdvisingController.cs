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
            bool status = postToWebApi(studentDetails);
            if(status)
            {
                return View(new StudentAdvisingData());
            }
            return View(data);
        }

        private bool postToWebApi(UCMStudent studentDetails)
        {
            string url = System.Web.Configuration.WebConfigurationManager.AppSettings["baseUrl"];
            string uri = System.Web.Configuration.WebConfigurationManager.AppSettings["addStudent"];
            var jsonString = new JavaScriptSerializer().Serialize(studentDetails);
            var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
            using (var client = new HttpClient())
            {
                var httpResponse = client.PostAsync(url + uri, httpContent).Result;
                if (httpResponse.Content != null)
                {
                    var responseContent = httpResponse.Content.ReadAsStringAsync().Result;
                    return responseContent.Equals("Success") ? true : false;
                }
            }
            return false;
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