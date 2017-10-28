namespace Workforce_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Availablebool : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Computers", "Available", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Computers", "Available");
        }
    }
}
