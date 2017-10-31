namespace Workforce_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixedModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Computers",
                c => new
                    {
                        ComputerId = c.Int(nullable: false, identity: true),
                        ComputerName = c.String(),
                        ComputerManufacturer = c.String(),
                        PurchaseDate = c.DateTime(nullable: false),
                        Avaliable = c.Boolean(nullable: false),
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
                        Department_DepartmentId = c.Int(),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.Computers", t => t.ComputerId, cascadeDelete: true)
                .ForeignKey("dbo.Departments", t => t.Department_DepartmentId)
                .Index(t => t.ComputerId)
                .Index(t => t.Department_DepartmentId);
            
            CreateTable(
                "dbo.TrainingPrograms",
                c => new
                    {
                        TrainingProgramId = c.Int(nullable: false, identity: true),
                        TrainingProgramName = c.String(),
                    })
                .PrimaryKey(t => t.TrainingProgramId);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentId = c.Int(nullable: false, identity: true),
                        DepartmentName = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DepartmentId);
            
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
            DropForeignKey("dbo.Employees", "Department_DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Employees", "ComputerId", "dbo.Computers");
            DropForeignKey("dbo.TrainingProgramEmployees", "Employee_EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.TrainingProgramEmployees", "TrainingProgram_TrainingProgramId", "dbo.TrainingPrograms");
            DropIndex("dbo.TrainingProgramEmployees", new[] { "Employee_EmployeeId" });
            DropIndex("dbo.TrainingProgramEmployees", new[] { "TrainingProgram_TrainingProgramId" });
            DropIndex("dbo.Employees", new[] { "Department_DepartmentId" });
            DropIndex("dbo.Employees", new[] { "ComputerId" });
            DropTable("dbo.TrainingProgramEmployees");
            DropTable("dbo.Departments");
            DropTable("dbo.TrainingPrograms");
            DropTable("dbo.Employees");
            DropTable("dbo.Computers");
        }
    }
}
