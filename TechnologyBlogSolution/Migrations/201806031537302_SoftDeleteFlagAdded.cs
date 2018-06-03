namespace TechnologyBlogSolution.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SoftDeleteFlagAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Posts", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Subjects", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Subjects", "IsDeleted");
            DropColumn("dbo.Posts", "IsDeleted");
            DropColumn("dbo.Comments", "IsDeleted");
        }
    }
}
