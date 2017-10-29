using System.Collections.Generic;

namespace Workforce_Management.Models
{
    public class Departement
    {
        public int DepartementId { get; set; }
        public string DepartementName { get; set; }
        public virtual List<Employee> Employee { get; set; }
    }
}