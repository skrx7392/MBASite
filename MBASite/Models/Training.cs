using System.Collections.Generic;

namespace MBASite.Models
{
    public class Training
    {
        public Training()
        {
            this.UCMStudents = new HashSet<UCMStudent>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<UCMStudent> UCMStudents { get; set; }
    }
}