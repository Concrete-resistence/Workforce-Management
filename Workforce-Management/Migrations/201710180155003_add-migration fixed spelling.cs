namespace Workforce_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmigrationfixedspelling : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Departments", "DepartmentDetails", c => c.String());
            DropColumn("dbo.Departments", "DepartmentDeatils");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Departments", "DepartmentDeatils", c => c.String());
            DropColumn("dbo.Departments", "DepartmentDetails");
        }
    }
}
