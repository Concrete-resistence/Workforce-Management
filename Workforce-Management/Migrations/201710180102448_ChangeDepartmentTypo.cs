namespace Workforce_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDepartmentTypo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Departements", "DepartementName", c => c.String());
            DropColumn("dbo.Departements", "DepartmentName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Departements", "DepartmentName", c => c.String());
            DropColumn("dbo.Departements", "DepartementName");
        }
    }
}
