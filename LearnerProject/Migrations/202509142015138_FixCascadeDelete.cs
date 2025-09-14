namespace LearnerProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixCascadeDelete : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CourseVideos", "TeacherId", "dbo.Teachers");
            AddForeignKey("dbo.CourseVideos", "TeacherId", "dbo.Teachers", "TeacherId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CourseVideos", "TeacherId", "dbo.Teachers");
            AddForeignKey("dbo.CourseVideos", "TeacherId", "dbo.Teachers", "TeacherId", cascadeDelete: true);
        }
    }
}
