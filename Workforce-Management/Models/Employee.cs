using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Workforce_Management.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        [Display(Name = "Employee First Name")]
        public string EmployeeFirstName { get; set; }
        [Display(Name = "Employee Last Name")]
        public string EmployeeLastName { get; set; }
        [Display(Name = "Hiring Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime HiringDate { get; set; }
        public virtual int ComputerId { get; set; }
        public virtual int DepartementId { get; set; }
        public virtual List<TrainingProgram> TrainingPrograms { get; set;}
    }
}