using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MBASite.ViewModels
{
    public class StudentAdvisingData
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Concentration { get; set; }
        public string Advisor { get; set; }
        public bool approvedForGraduation { get; set; }
        public string ProgramStatus { get; set; }
        public string Comments { get; set; }
    }
}