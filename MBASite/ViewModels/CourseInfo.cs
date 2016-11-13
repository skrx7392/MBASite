using System.Collections.Generic;
using System.ComponentModel;

namespace MBASite.ViewModels
{
    public class CourseInfo
    {
        [DisplayName("Concentration Code")]
        public string ConcentrationCode { get; set; }
        [DisplayName("Course Number")]
        public int CourseNumber { get; set; }
        [DisplayName("Course Name")]
        public string CourseName { get; set; }
        [DisplayName("Program ID")]
        public int ProgramId { get; set; }
        [DisplayName("PreReq IDs")]
        public List<string> PreReqIds { get; set; }
    }
}