using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MBASite.Models
{
    public class StudentDetails
    {
        public string AlternateEmail { get; set; }
        public string CreatedDate { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public int Id { get; set; }
        public string LastName { get; set; }
        public string ModifiedDate { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public int RoleId { get; set; }
        public string Address { get; set; }
        public bool ApprovedGrad { get; set; }
        public string Comments { get; set; }
        public int? GMATScore { get; set; }
        public double? GPA { get; set; }
        public int? GREScore { get; set; }
        public string PhoneNumber { get; set; }
        public string Program { get; set; }
        public int? ProgramId { get; set; }
        public string StartDate { get; set; }
        public int? StudentTrainingStatusId { get; set; }
        public string Student_AcademicStatus { get; set; }
        public int? Student_AcademicStatusId { get; set; }
        public string Student_TrainingStatus { get; set; }
        public string Training { get; set; }
        public int? TrainingId { get; set; }
        public bool PrereqsMet { get; set; }
    }
}