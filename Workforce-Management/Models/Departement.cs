using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Workforce_Management.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        [Display(Name ="Department Name")]
        public string DepartmentName { get; set; }
        [Display(Name = "Department Details")]
        public string DepartmentDetails { get; set; }
        public virtual List<Employee> EmployeeId { get; set; }
    }
}