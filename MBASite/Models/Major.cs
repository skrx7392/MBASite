using System.Collections.Generic;

namespace MBASite.Models
{
    public class Major
    {
        public Major()
        {
            HashSet<Program> hs = new HashSet<Program>();
            this.Programs = new List<Program>(hs);
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual List<Program> Programs { get; set; }
    }
}