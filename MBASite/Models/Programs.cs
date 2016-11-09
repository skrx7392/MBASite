using System.Collections.Generic;

namespace MBASite.Models
{
    public class Programs
    {
        public string Conc_Code { get; set; }
        public int? Id { get; set; }
        public string Major { get; set; }
        public int MajorId { get; set; }
        public string Name { get; set; }
        public List<string> UCMStudents { get; set; }
        public List<string> courses { get; set; }
    }
}