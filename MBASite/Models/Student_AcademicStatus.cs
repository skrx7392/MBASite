using System.Collections.Generic;

namespace MBASite.Models
{
    public class Student_AcademicStatus
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Student_AcademicStatus()
        {
            HashSet<UCMStudent> hs = new HashSet<UCMStudent>();
            this.UCMStudents = new List<UCMStudent>(hs);
        }

        public int ID { get; set; }
        public string AcademicStatus { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual List<UCMStudent> UCMStudents { get; set; }
    }
}