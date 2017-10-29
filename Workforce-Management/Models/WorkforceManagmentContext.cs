using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Workforce_Management.Models
{
    public class WorkforceManagement   :DbContext
    {
        public WorkforceManagement() : base("name=WorkforceManagement")
        {
        }
        public System.Data.Entity.DbSet<Workforce_Management.Models.Computer> Computer { get; set; }
        public System.Data.Entity.DbSet<Workforce_Management.Models.Departement> Departement { get; set; }
        public System.Data.Entity.DbSet<Workforce_Management.Models.Employee> Employee { get; set; }
        public System.Data.Entity.DbSet<Workforce_Management.Models.TrainingProgram> TrainingProgram { get; set; }
    }
}

