namespace Workforce_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeDepartementIdToString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Departements", "DepartmentName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Departements", "DepartmentName", c => c.Int(nullable: false));
        }
    }
}
