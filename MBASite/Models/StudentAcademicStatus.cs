using System.Collections.Generic;

namespace MBASite.Models
{
    public class StudentAcademicStatus
    {
        public string AcademicStatus { get; set; }
        public int? ID { get; set; }
        public List<string> UCMStudents { get; set; }
    }
}