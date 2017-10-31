namespace Workforce_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateTimeFixAttempt1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TrainingPrograms", "StartDate", c => c.DateTime());
            AlterColumn("dbo.TrainingPrograms", "EndDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TrainingPrograms", "EndDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.TrainingPrograms", "StartDate", c => c.DateTime(nullable: false));
        }
    }
}
