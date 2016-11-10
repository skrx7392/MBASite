using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MBASite.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CourseNumber { get; set; }
        public string ConcentrationCode { get; set; }
        public int ProgramId { get; set; }
        public string PreqId { get; set; }

        public virtual Program Program { get; set; }
    }
}