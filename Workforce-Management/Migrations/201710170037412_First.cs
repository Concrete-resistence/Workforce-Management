namespace Workforce_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Computers",
                c => new
                    {
                        ComputerId = c.Int(nullable: false, identity: true),
                        ComputerName = c.String(),
                    })
                .PrimaryKey(t => t.ComputerId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        EmployeeFirstName = c.String(),
                        EmployeeLastName = c.String(),
                        HiringDate = c.DateTime(nullable: false),
                        ComputerId = c.Int(nullable: false),
                        DepartementId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.Computers", t => t.ComputerId, cascadeDelete: true)
                .ForeignKey("dbo.Departements", t => t.DepartementId, cascadeDelete: true)
                .Index(t => t.ComputerId)
                .Index(t => t.DepartementId);
            
            CreateTable(
                "dbo.TrainingPrograms",
                c => new
                    {
                        TrainingProgramId = c.Int(nullable: false, identity: true),
                        TrainingProgramName = c.String(),
                    })
                .PrimaryKey(t => t.TrainingProgramId);
            
            CreateTable(
                "dbo.Departements",
                c => new
                    {
                        DepartementId = c.Int(nullable: false, identity: true),
                        DepartmentName = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DepartementId);
            
            CreateTable(
                "dbo.TrainingProgramEmployees",
                c => new
                    {
                        TrainingProgram_TrainingProgramId = c.Int(nullable: false),
                        Employee_EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TrainingProgram_TrainingProgramId, t.Employee_EmployeeId })
                .ForeignKey("dbo.TrainingPrograms", t => t.TrainingProgram_TrainingProgramId, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.Employee_EmployeeId, cascadeDelete: true)
                .Index(t => t.TrainingProgram_TrainingProgramId)
                .Index(t => t.Employee_EmployeeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "DepartementId", "dbo.Departements");
            DropForeignKey("dbo.Employees", "ComputerId", "dbo.Computers");
            DropForeignKey("dbo.TrainingProgramEmployees", "Employee_EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.TrainingProgramEmployees", "TrainingProgram_TrainingProgramId", "dbo.TrainingPrograms");
            DropIndex("dbo.TrainingProgramEmployees", new[] { "Employee_EmployeeId" });
            DropIndex("dbo.TrainingProgramEmployees", new[] { "TrainingProgram_TrainingProgramId" });
            DropIndex("dbo.Employees", new[] { "DepartementId" });
            DropIndex("dbo.Employees", new[] { "ComputerId" });
            DropTable("dbo.TrainingProgramEmployees");
            DropTable("dbo.Departements");
            DropTable("dbo.TrainingPrograms");
            DropTable("dbo.Employees");
            DropTable("dbo.Computers");
        }
    }
}
