using System.Collections.Generic;

namespace MBASite.Models
{
    public class StudentTrainingStatus
    {
        public int? Id { get; set; }
        public string TrainingStatus { get; set; }
        public List<string> UCMStudents { get; set; }
    }
}