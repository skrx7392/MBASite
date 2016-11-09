using System.Collections.Generic;

namespace MBASite.ViewModels
{
    public class PrerequisiteCourses
    {
        public string ConcentrationCode { get; set; }
        public int CourseNumber { get; set; }
        public List<int> PrereqIds { get; set; }
        public List<string> PrereqCourses { get; set; }
    }
}