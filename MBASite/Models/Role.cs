using System.Collections.Generic;

namespace MBASite.Models
{
    public class Role
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Role()
        {
            HashSet<UCMUser> hs = new HashSet<UCMUser>();
            this.UCMUsers = new List<UCMUser>(hs);
        }

        public int Id { get; set; }
        public string Name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual List<UCMUser> UCMUsers { get; set; }
    }
}