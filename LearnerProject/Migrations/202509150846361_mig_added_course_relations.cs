namespace LearnerProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_added_course_relations : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CourseVideos", "Course_CourseId", c => c.Int());
            CreateIndex("dbo.CourseVideos", "Course_CourseId");
            AddForeignKey("dbo.CourseVideos", "Course_CourseId", "dbo.Courses", "CourseId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CourseVideos", "Course_CourseId", "dbo.Courses");
            DropIndex("dbo.CourseVideos", new[] { "Course_CourseId" });
            DropColumn("dbo.CourseVideos", "Course_CourseId");
        }
    }
}
