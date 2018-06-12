namespace TechnologyBlogSolution.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRelationFromPostToParentSubject : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Posts", "Subject_Id", "dbo.Subjects");
            DropIndex("dbo.Posts", new[] { "Subject_Id" });
            AlterColumn("dbo.Posts", "Subject_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Posts", "Subject_Id");
            AddForeignKey("dbo.Posts", "Subject_Id", "dbo.Subjects", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "Subject_Id", "dbo.Subjects");
            DropIndex("dbo.Posts", new[] { "Subject_Id" });
            AlterColumn("dbo.Posts", "Subject_Id", c => c.Int());
            CreateIndex("dbo.Posts", "Subject_Id");
            AddForeignKey("dbo.Posts", "Subject_Id", "dbo.Subjects", "Id");
        }
    }
}
