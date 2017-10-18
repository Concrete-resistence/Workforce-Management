using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Workforce_Management.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public virtual List<Employee> EmployeeId { get; set; }
    }
}