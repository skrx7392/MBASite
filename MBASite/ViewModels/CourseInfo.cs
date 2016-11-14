using System.Collections.Generic;
using System.ComponentModel;

namespace MBASite.ViewModels
{
    public class CourseInfo
    {
        public int Id { get; set; }
        [DisplayName("Concentration Code")]
        public string ConcentrationCode { get; set; }
        [DisplayName("Course Number")]
        public string CourseNumber { get; set; }
        [DisplayName("Course Name")]
        public string CourseName { get; set; }
        [DisplayName("PreReq IDs")]
        public string PreReqId { get; set; }
        [DisplayName("Is Active")]
        public bool Status { get; set; }
    }
}