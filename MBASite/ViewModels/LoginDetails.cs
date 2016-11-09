using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MBASite.ViewModels
{
    public class LoginDetails
    {
        [Required(ErrorMessage = "Required")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Must be 10 characters lone")]
        [RegularExpression("[0-9]", ErrorMessage = "Username must contain only numbers")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}