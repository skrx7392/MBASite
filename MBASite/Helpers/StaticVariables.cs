using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MBASite.Models;

namespace MBASite.Helpers
{
    public class StaticVariables
    {
        public static string Role;
        public static List<Role> Roles;
        public static List<UCMStudent> StudentDetails;
        public static List<UCMModerator> AdvisorDetails;
        public static List<Program> Programs;
        public static List<Course> Courses;
        public static List<Student_TrainingStatus> TrainingStatuses;
        public static List<Student_AcademicStatus> AcademicStatuses;
        public static List<Training> Trainings;
    }
}