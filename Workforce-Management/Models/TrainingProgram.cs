using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Workforce_Management.Models
{
    public class TrainingProgram
    {
        public int TrainingProgramId { get; set; }
        public string TrainingProgramName { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int MaxAttendees { get; set; }
        public virtual List<Employee> Employee { get; set; }
    }
}