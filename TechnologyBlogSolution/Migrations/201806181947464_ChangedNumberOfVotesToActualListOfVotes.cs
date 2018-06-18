namespace TechnologyBlogSolution.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedNumberOfVotesToActualListOfVotes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Votes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        User_Id = c.String(maxLength: 128),
                        Timestamp = c.DateTime(nullable: false),
                        Post_Id = c.Int(),
                        Post_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .ForeignKey("dbo.Posts", t => t.Post_Id)
                .ForeignKey("dbo.Posts", t => t.Post_Id1)
                .Index(t => t.User_Id)
                .Index(t => t.Post_Id)
                .Index(t => t.Post_Id1);
            
            DropColumn("dbo.Posts", "NumberOfUpvotes");
            DropColumn("dbo.Posts", "NumberOfDownvotes");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "NumberOfDownvotes", c => c.Int(nullable: false));
            AddColumn("dbo.Posts", "NumberOfUpvotes", c => c.Int(nullable: false));
            DropForeignKey("dbo.Votes", "Post_Id1", "dbo.Posts");
            DropForeignKey("dbo.Votes", "Post_Id", "dbo.Posts");
            DropForeignKey("dbo.Votes", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Votes", new[] { "Post_Id1" });
            DropIndex("dbo.Votes", new[] { "Post_Id" });
            DropIndex("dbo.Votes", new[] { "User_Id" });
            DropTable("dbo.Votes");
        }
    }
}
