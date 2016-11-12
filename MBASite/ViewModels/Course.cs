using System.Collections.Generic;

namespace MBASite.ViewModels
{
    public class Course
    {
        public string ConcentrationCode { get; set; }
        public int CourseNumber { get; set; }
        public string CourseName { get; set; }
        public int ProgramId { get; set; }
        public List<string> PreReqIds { get; set; }
    }
}