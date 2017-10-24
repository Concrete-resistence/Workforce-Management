using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Workforce_Management.Models; 
namespace Workforce_Management.ViewModels
{
    public class EmployeeView 
    {
        public int EmployeeId { get; set; }
        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }
        public string ComputerName { get; set; }
        public string DepatrementNmae { get; set; }
        public  List<TrainingProgram> TrainingPrograms{ get; set; }
    }
}