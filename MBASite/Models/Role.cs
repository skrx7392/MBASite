using System.Collections.Generic;

namespace MBASite.Models
{
    public class Role
    {
        public Role()
        {
            this.UCMUsers = new HashSet<UCMUser>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<UCMUser> UCMUsers { get; set; }
    }
}