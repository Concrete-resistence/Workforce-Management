using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Workforce_Management.Models
{
    public class Departement
    {
        public int DepartementId { get; set; }
        public string DepartementName { get; set; }
        public virtual List<Employee> EmployeeId { get; set; }
    }
}