using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MBASite.ViewModels
{
    public class AdvisorData
    {
        public int AdvisorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Concentration { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }
    }
}