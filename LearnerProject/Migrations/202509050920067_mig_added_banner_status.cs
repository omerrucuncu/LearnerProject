namespace LearnerProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_added_banner_status : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Banners", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Banners", "Status");
        }
    }
}
