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
        public int Username { get; set; }
        [Required(ErrorMessage = "Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}