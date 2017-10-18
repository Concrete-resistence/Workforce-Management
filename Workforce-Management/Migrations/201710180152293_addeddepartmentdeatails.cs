namespace Workforce_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addeddepartmentdeatails : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Departments", "DepartmentDeatils", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Departments", "DepartmentDeatils");
        }
    }
}
