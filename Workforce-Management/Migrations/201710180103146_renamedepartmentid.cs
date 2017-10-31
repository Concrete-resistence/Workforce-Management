namespace Workforce_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class renamedepartmentid : DbMigration
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
                    })
                .PrimaryKey(t => t.DepartmentId);
            
            AddColumn("dbo.Employees", "DepartmentId", c => c.Int(nullable: false));
            CreateIndex("dbo.Employees", "DepartmentId");
            AddForeignKey("dbo.Employees", "DepartmentId", "dbo.Departments", "DepartmentId", cascadeDelete: true);
            DropColumn("dbo.Employees", "DepartementId");
            DropTable("dbo.Departements");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Departements",
                c => new
                    {
                        DepartementId = c.Int(nullable: false, identity: true),
                        DepartmentName = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DepartementId);
            
            AddColumn("dbo.Employees", "DepartementId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Employees", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Employees", new[] { "DepartmentId" });
            DropColumn("dbo.Employees", "DepartmentId");
            DropTable("dbo.Departments");
            CreateIndex("dbo.Employees", "DepartementId");
            AddForeignKey("dbo.Employees", "DepartementId", "dbo.Departements", "DepartementId", cascadeDelete: true);
        }
    }
}
