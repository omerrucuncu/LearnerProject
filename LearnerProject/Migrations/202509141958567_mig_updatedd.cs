namespace LearnerProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_updatedd : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CourseVideos", "TeacherId", "dbo.Teachers");
            DropIndex("dbo.CourseVideos", new[] { "TeacherId" });
            AlterColumn("dbo.CourseVideos", "TeacherId", c => c.Int(nullable: false));
            CreateIndex("dbo.CourseVideos", "TeacherId");
            AddForeignKey("dbo.CourseVideos", "TeacherId", "dbo.Teachers", "TeacherId", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CourseVideos", "TeacherId", "dbo.Teachers");
            DropIndex("dbo.CourseVideos", new[] { "TeacherId" });
            AlterColumn("dbo.CourseVideos", "TeacherId", c => c.Int());
            CreateIndex("dbo.CourseVideos", "TeacherId");
            AddForeignKey("dbo.CourseVideos", "TeacherId", "dbo.Teachers", "TeacherId");
        }
    }
}
