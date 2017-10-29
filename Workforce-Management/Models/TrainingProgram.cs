using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Workforce_Management.Models
{
    public class TrainingProgram
    {
        public int TrainingProgramId { get; set; }
        public string TrainingProgramName { get; set; }
        public string Description { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        public virtual DateTime? StartDate { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        public virtual DateTime? EndDate { get; set; }
        public int MaxAttendees { get; set; }
        public virtual List<Employee> Employee { get; set; }
    }
}