namespace TechnologyBlogSolution.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedVotesFromSolution : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Votes", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Votes", "Post_Id", "dbo.Posts");
            DropForeignKey("dbo.Votes", "Post_Id1", "dbo.Posts");
            DropIndex("dbo.Votes", new[] { "User_Id" });
            DropIndex("dbo.Votes", new[] { "Post_Id" });
            DropIndex("dbo.Votes", new[] { "Post_Id1" });
            DropTable("dbo.Votes");
        }
        
        public override void Down()
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
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Votes", "Post_Id1");
            CreateIndex("dbo.Votes", "Post_Id");
            CreateIndex("dbo.Votes", "User_Id");
            AddForeignKey("dbo.Votes", "Post_Id1", "dbo.Posts", "Id");
            AddForeignKey("dbo.Votes", "Post_Id", "dbo.Posts", "Id");
            AddForeignKey("dbo.Votes", "User_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
