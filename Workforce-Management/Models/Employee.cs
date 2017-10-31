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
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime HiringDate { get; set; }
        public virtual int ComputerId { get; set; }
        public virtual int DepartmentId { get; set; }
        public virtual List<TrainingProgram> TrainingPrograms { get; set;}

    }
}