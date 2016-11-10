using System.Collections.Generic;

namespace MBASite.Models
{
    public class Program
    {
        public Program()
        {
            this.courses = new HashSet<Course>();
            this.UCMStudents = new HashSet<UCMStudent>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int MajorId { get; set; }
        public string Conc_Code { get; set; }

        public virtual ICollection<Course> courses { get; set; }
        public virtual Major Major { get; set; }
        public virtual ICollection<UCMStudent> UCMStudents { get; set; }
    }
}