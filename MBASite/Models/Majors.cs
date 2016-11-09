using System.Collections.Generic;

namespace MBASite.Models
{
    public class Majors
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public List<string> UCMStudents { get; set; }
    }
}