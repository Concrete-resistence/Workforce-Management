namespace Workforce_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeTables : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employees", "DepartementId", "dbo.Departements");
            DropIndex("dbo.Employees", new[] { "DepartementId" });
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentId = c.Int(nullable: false, identity: true),
                        DepartmentName = c.String(),
                        DepartmentDetails = c.String(),
                    })
                .PrimaryKey(t => t.DepartmentId);
            
            AddColumn("dbo.Employees", "Department_DepartmentId", c => c.Int());
            CreateIndex("dbo.Employees", "Department_DepartmentId");
            AddForeignKey("dbo.Employees", "Department_DepartmentId", "dbo.Departments", "DepartmentId");
            DropTable("dbo.Departements");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Departements",
                c => new
                    {
                        DepartementId = c.Int(nullable: false, identity: true),
                        DepartementName = c.String(),
                    })
                .PrimaryKey(t => t.DepartementId);
            
            DropForeignKey("dbo.Employees", "Department_DepartmentId", "dbo.Departments");
            DropIndex("dbo.Employees", new[] { "Department_DepartmentId" });
            DropColumn("dbo.Employees", "Department_DepartmentId");
            DropTable("dbo.Departments");
            CreateIndex("dbo.Employees", "DepartementId");
            AddForeignKey("dbo.Employees", "DepartementId", "dbo.Departements", "DepartementId", cascadeDelete: true);
        }
    }
}
