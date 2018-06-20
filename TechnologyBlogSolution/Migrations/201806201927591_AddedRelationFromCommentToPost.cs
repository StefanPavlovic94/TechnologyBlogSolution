namespace TechnologyBlogSolution.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRelationFromCommentToPost : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "Post_Id", "dbo.Posts");
            DropIndex("dbo.Comments", new[] { "Post_Id" });
            AlterColumn("dbo.Comments", "Post_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Comments", "Post_Id");
            AddForeignKey("dbo.Comments", "Post_Id", "dbo.Posts", "Id", cascadeDelete: true);
            DropColumn("dbo.Comments", "NumberofUpvotes");
            DropColumn("dbo.Comments", "NumberOfDownvotes");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comments", "NumberOfDownvotes", c => c.Int(nullable: false));
            AddColumn("dbo.Comments", "NumberofUpvotes", c => c.Int(nullable: false));
            DropForeignKey("dbo.Comments", "Post_Id", "dbo.Posts");
            DropIndex("dbo.Comments", new[] { "Post_Id" });
            AlterColumn("dbo.Comments", "Post_Id", c => c.Int());
            CreateIndex("dbo.Comments", "Post_Id");
            AddForeignKey("dbo.Comments", "Post_Id", "dbo.Posts", "Id");
        }
    }
}
