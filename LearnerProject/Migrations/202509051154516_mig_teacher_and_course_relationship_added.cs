namespace LearnerProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_teacher_and_course_relationship_added : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Courses", "Teacher_TeacherId", "dbo.Teachers");
            DropIndex("dbo.Courses", new[] { "Teacher_TeacherId" });
            RenameColumn(table: "dbo.Courses", name: "Teacher_TeacherId", newName: "TeacherId");
            AlterColumn("dbo.Courses", "TeacherId", c => c.Int(nullable: true));
            CreateIndex("dbo.Courses", "TeacherId");
            AddForeignKey("dbo.Courses", "TeacherId", "dbo.Teachers", "TeacherId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "TeacherId", "dbo.Teachers");
            DropIndex("dbo.Courses", new[] { "TeacherId" });
            AlterColumn("dbo.Courses", "TeacherId", c => c.Int());
            RenameColumn(table: "dbo.Courses", name: "TeacherId", newName: "Teacher_TeacherId");
            CreateIndex("dbo.Courses", "Teacher_TeacherId");
            AddForeignKey("dbo.Courses", "Teacher_TeacherId", "dbo.Teachers", "TeacherId");
        }
    }
}
