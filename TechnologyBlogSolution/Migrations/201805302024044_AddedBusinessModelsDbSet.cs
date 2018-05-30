namespace TechnologyBlogSolution.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedBusinessModelsDbSet : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        Timestamp = c.DateTime(nullable: false),
                        Author_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Author_Id)
                .Index(t => t.Author_Id);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Content = c.String(),
                        Timestamp = c.DateTime(nullable: false),
                        Author_Id = c.String(maxLength: 128),
                        Subject_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Author_Id)
                .ForeignKey("dbo.Subjects", t => t.Subject_Id)
                .Index(t => t.Author_Id)
                .Index(t => t.Subject_Id);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "Subject_Id", "dbo.Subjects");
            DropForeignKey("dbo.Posts", "Author_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comments", "Author_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Posts", new[] { "Subject_Id" });
            DropIndex("dbo.Posts", new[] { "Author_Id" });
            DropIndex("dbo.Comments", new[] { "Author_Id" });
            DropTable("dbo.Subjects");
            DropTable("dbo.Posts");
            DropTable("dbo.Comments");
        }
    }
}
