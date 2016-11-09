using System.Collections.Generic;

namespace MBASite.Models
{
    public class Student_AcademicStatus
    {
        public Student_AcademicStatus()
        {
            this.UCMStudents = new HashSet<UCMStudent>();
        }
        public string AcademicStatus { get; set; }
        public int ID { get; set; }
        public virtual ICollection<UCMStudent> UCMStudents { get; set; }
    }
}