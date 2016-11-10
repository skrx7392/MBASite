using System.Collections.Generic;

namespace MBASite.Models
{
    public class Student_TrainingStatus
    {
        public Student_TrainingStatus()
        {
            this.UCMStudents = new HashSet<UCMStudent>();
        }
        public int Id { get; set; }
        public string TrainingStatus { get; set; }
        public virtual ICollection<UCMStudent> UCMStudents { get; set; }
    }
}