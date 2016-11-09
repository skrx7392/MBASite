using System.Collections.Generic;

namespace MBASite.Models
{
    public class Roles
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public List<string> UCMUsers { get; set; }
    }
}