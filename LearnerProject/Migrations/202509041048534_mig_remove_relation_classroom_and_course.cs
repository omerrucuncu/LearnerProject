namespace LearnerProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_remove_relation_classroom_and_course : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Courses", "ClubId", "dbo.Clubs");
            DropIndex("dbo.Courses", new[] { "ClubId" });
            DropColumn("dbo.Courses", "ClubId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "ClubId", c => c.Int(nullable: false));
            CreateIndex("dbo.Courses", "ClubId");
            AddForeignKey("dbo.Courses", "ClubId", "dbo.Clubs", "ClubId", cascadeDelete: true);
        }
    }
}
