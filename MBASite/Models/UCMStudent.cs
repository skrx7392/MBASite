﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MBASite.Models
{
    public class UCMStudent : UCMUser
    {
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int ProgramId { get; set; }
        public decimal GPA { get; set; }
        public Nullable<int> GREScore { get; set; }
        public Nullable<int> GMATScore { get; set; }
        public System.DateTime StartDate { get; set; }
        public Nullable<int> TrainingId { get; set; }
        public Nullable<int> StudentTrainingStatusId { get; set; }
        public int Student_AcademicStatusId { get; set; }
        public string Comments { get; set; }
        public Nullable<bool> ApprovedGrad { get; set; }
        public Nullable<bool> PrereqsMet { get; set; }
        public Nullable<int> Advisor { get; set; }

        public virtual Program Program { get; set; }
        public virtual Student_AcademicStatus Student_AcademicStatus { get; set; }
        public virtual Student_TrainingStatus Student_TrainingStatus { get; set; }
        public virtual Training Training { get; set; }
    }
}