using System.Collections.Generic;

namespace MBASite.Models
{
    public class Major
    {
        public Major()
        {
            this.Programs = new HashSet<Program>();
        }

        public int? Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Program> Programs { get; set; }
    }
}