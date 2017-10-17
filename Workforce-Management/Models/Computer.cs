using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Workforce_Management.Models
{
    public class Computer
    {
        public int ComputerId { get; set; }
        public string ComputerName { get; set; }
        public virtual List<Employee> Employee { get; set; }
    }
}