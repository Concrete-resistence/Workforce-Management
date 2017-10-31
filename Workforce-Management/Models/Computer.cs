using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Workforce_Management.Models
{
    public class Computer
    {
        public int ComputerId { get; set; }
        [Display(Name="Computer")]
        public string ComputerName { get; set; }
        [Display(Name = "Manufacturer")]
        public string ComputerManufacturer { get; set; }
        [DataType(DataType.Date)]
        [Display(Name ="Purchase Date")]
        public DateTime PurchaseDate { get; set; }
        public bool Avaliable { get; set; }
        public virtual List<Employee> Employee { get; set; }
    }
}