using System.Collections.Generic;

namespace MBASite.Models
{
    public class Program
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Program()
        {
            HashSet<Course> hs = new HashSet<Course>();
            this.courses = new List<Course>(hs);
            HashSet<UCMStudent> hs1 = new HashSet<UCMStudent>();
            this.UCMStudents = new List<UCMStudent>(hs1);
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int MajorId { get; set; }
        public string Conc_Code { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual List<Course> courses { get; set; }
        public virtual Major Major { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual List<UCMStudent> UCMStudents { get; set; }
    }
}