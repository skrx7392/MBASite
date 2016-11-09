﻿using System.Collections.Generic;

namespace MBASite.ViewModels
{
    public class AdvisorData
    {
        public int AdvisorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<string> Concentration { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public bool Status { get; set; }
    }
}