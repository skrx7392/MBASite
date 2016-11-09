using System.Collections.Generic;

namespace MBASite.Models
{
    public class TrainingData
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public List<string> UCMStudents { get; set; }
    }
}