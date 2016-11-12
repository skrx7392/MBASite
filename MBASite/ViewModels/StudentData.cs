using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MBASite.ViewModels
{
    public class StudentData
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Concentration { get; set; }
        public string Address { get; set; }
        [Required(ErrorMessage = "Telephone Number Required")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Entered phone format is not valid.")]
        public string PhoneNumber { get; set; }
        [DataType(DataType.Date)]
        public DateTime ProgramEntryDate { get; set; }
        public int GMATScore { get; set; }
        public int GREScore { get; set; }
        public decimal GPA { get; set; }
        [RegularExpression(".+@.+\\..+", ErrorMessage = "Please Enter Correct Email Address")]
        public string UCMOEmailId { get; set; }
        [RegularExpression(".+@.+\\..+", ErrorMessage = "Please Enter Correct Email Address")]
        public string NonUCMOEmailId { get; set; }
       
        public string Comments { get; set; }
    }
}