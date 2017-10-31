namespace Workforce_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fuckVS : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Employees", new[] { "departmentId" });
            CreateIndex("dbo.Employees", "DepartmentId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Employees", new[] { "DepartmentId" });
            CreateIndex("dbo.Employees", "departmentId");
        }
    }
}
