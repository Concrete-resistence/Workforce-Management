using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Workforce_Management.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }
        public DateTime HiringDate { get; set; }
        public virtual int ComputerId { get; set; }
        public virtual int DepartementId { get; set; }
        public virtual List<TrainingProgram> TrainingPrograms { get; set;}
    }
}