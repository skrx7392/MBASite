using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MBASite.ViewModels
{
    public class ViewProgram
    {
        public int Id { get; set; }
        public string ConcentrationCode { get; set; }
        public string ConcentrationName { get; set; }
        public int MajorId { get; set; }
        public bool IsActive { get; set; }
    }
}