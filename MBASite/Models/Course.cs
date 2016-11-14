using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MBASite.Models
{
    public class Course
    {

        public int Id { get; set; }
        [DisplayName("Course Name")]
        public string Name { get; set; }
        [DisplayName("Course Number")]
        public string CourseNumber { get; set; }
        [DisplayName("Concentration Code")]
        public string CCode { get; set; }
        [DisplayName("Prerequisite ID")]
        public string PreqId { get; set; }
        [DisplayName("Is Active")]
        public bool? PrereqIsActive { get; set; }
    }
}