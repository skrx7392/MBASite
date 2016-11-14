using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MBASite.ViewModels
{
    public class AdvisorData
    {
        [DisplayName("Advisor ID")]
        public int AdvisorId { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [DisplayName("Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DisplayName("Concentration")]
        public string Concentration { get; set; }
        [DisplayName("Email")]
        public string Email { get; set; }
        [DisplayName("Status")]
        public bool Status { get; set; }
    }
}