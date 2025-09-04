namespace LearnerProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class status_properties_added : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.Clubs", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.Contacts", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.CourseRegisters", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.Students", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.Reviews", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.CourseVideos", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CourseVideos", "Status");
            DropColumn("dbo.Reviews", "Status");
            DropColumn("dbo.Students", "Status");
            DropColumn("dbo.CourseRegisters", "Status");
            DropColumn("dbo.Contacts", "Status");
            DropColumn("dbo.Clubs", "Status");
            DropColumn("dbo.Courses", "Status");
        }
    }
}
