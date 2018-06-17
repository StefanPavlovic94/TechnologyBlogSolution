using System;
using System.Data.Entity.Migrations;

public partial class AddedUpvotesDownvotes : DbMigration
{
    public override void Up()
    {
        AddColumn("dbo.Comments", "NumberofUpvotes", c => c.Int(nullable: false));
        AddColumn("dbo.Comments", "NumberOfDownvotes", c => c.Int(nullable: false));
        AddColumn("dbo.Posts", "NumberOfUpvotes", c => c.Int(nullable: false));
        AddColumn("dbo.Posts", "NumberOfDownvotes", c => c.Int(nullable: false));
    }

    public override void Down()
    {
        DropColumn("dbo.Posts", "NumberOfDownvotes");
        DropColumn("dbo.Posts", "NumberOfUpvotes");
        DropColumn("dbo.Comments", "NumberOfDownvotes");
        DropColumn("dbo.Comments", "NumberofUpvotes");
    }
}

