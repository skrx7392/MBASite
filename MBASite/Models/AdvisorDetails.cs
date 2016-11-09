using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MBASite.Models
{
    public class AdvisorDetails
    {
        public string AlternateEmail { get; set; }
        public string CreatedDate { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public int Id { get; set; }
        public string LastName { get; set; }
        public string ModifiedDate { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public int RoleId { get; set; }
        public bool IsActive { get; set; }
    }
}