namespace TechnologyBlogSolution.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedRelationToVirtual : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "Post_Id", c => c.Int());
            CreateIndex("dbo.Comments", "Post_Id");
            AddForeignKey("dbo.Comments", "Post_Id", "dbo.Posts", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "Post_Id", "dbo.Posts");
            DropIndex("dbo.Comments", new[] { "Post_Id" });
            DropColumn("dbo.Comments", "Post_Id");
        }
    }
}
