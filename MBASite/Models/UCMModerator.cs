using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MBASite.Models
{
    public class UCMModerator : UCMUser
    {
        public bool IsActive { get; set; }
    }
}