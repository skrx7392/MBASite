using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MBASite.ViewModels
{
    public class StudentData
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Concentration { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string ProgramEntryDate { get; set; }
        public int GMATScore { get; set; }
        public int GREScore { get; set; }
        public double GPA { get; set; }
        public string UCMOEmailId { get; set; }
        public string NonUCMOEmailId { get; set; }
        public string Comments { get; set; }
    }
}