using System.Collections.Generic;

namespace MBASite.Models
{
    public class Training
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Training()
        {
            HashSet<UCMStudent> hs = new HashSet<UCMStudent>();
            this.UCMStudents = new List<UCMStudent>(hs);
        }

        public int Id { get; set; }
        public string Name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual List<UCMStudent> UCMStudents { get; set; }
    }
}