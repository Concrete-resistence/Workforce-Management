namespace Workforce_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingToTrainingPrograms : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TrainingPrograms", "Description", c => c.String());
            AddColumn("dbo.TrainingPrograms", "StartDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.TrainingPrograms", "EndDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.TrainingPrograms", "MaxAttendees", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TrainingPrograms", "MaxAttendees");
            DropColumn("dbo.TrainingPrograms", "EndDate");
            DropColumn("dbo.TrainingPrograms", "StartDate");
            DropColumn("dbo.TrainingPrograms", "Description");
        }
    }
}
