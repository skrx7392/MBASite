using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MBASite.Models;
using MBASite.ViewModels;

namespace MBASite.Helpers
{
    public class StaticVariables
    {
        public static string Role;
        public static List<StudentDetails> StudentDetails;
        public static List<AdvisorDetails> AdvisorDetails;
        public static List<Programs> Programs;
        public static List<Models.Course> Courses;
    }
}