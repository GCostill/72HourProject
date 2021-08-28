namespace _72HourProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CommentDatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        AuthorId = c.Guid(nullable: false),
                        PostId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Posts", t => t.PostId, cascadeDelete: true)
                .Index(t => t.PostId);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Text = c.String(),
                        AuthorId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        PostId = c.Int(nullable: false),
                        PostData_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Posts", t => t.PostId, cascadeDelete: true)
                .ForeignKey("dbo.PostDatas", t => t.PostData_Id)
                .Index(t => t.PostId)
                .Index(t => t.PostData_Id);
            
            CreateTable(
                "dbo.Replies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CommentId = c.Int(nullable: false),
                        Text = c.String(),
                        AuthorId = c.Guid(nullable: false),
                        CommentData_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Comments", t => t.CommentId, cascadeDelete: true)
                .ForeignKey("dbo.CommentDatas", t => t.CommentData_Id)
                .Index(t => t.CommentId)
                .Index(t => t.CommentData_Id);
            
            CreateTable(
                "dbo.PostDatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 25),
                        Text = c.String(nullable: false, maxLength: 1000),
                        AuthorId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ReplyDatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CommentId = c.Int(nullable: false),
                        Text = c.String(),
                        AuthorId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Comments", t => t.CommentId, cascadeDelete: true)
                .Index(t => t.CommentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReplyDatas", "CommentId", "dbo.Comments");
            DropForeignKey("dbo.Comments", "PostData_Id", "dbo.PostDatas");
            DropForeignKey("dbo.Replies", "CommentData_Id", "dbo.CommentDatas");
            DropForeignKey("dbo.CommentDatas", "PostId", "dbo.Posts");
            DropForeignKey("dbo.Replies", "CommentId", "dbo.Comments");
            DropForeignKey("dbo.Comments", "PostId", "dbo.Posts");
            DropIndex("dbo.ReplyDatas", new[] { "CommentId" });
            DropIndex("dbo.Replies", new[] { "CommentData_Id" });
            DropIndex("dbo.Replies", new[] { "CommentId" });
            DropIndex("dbo.Comments", new[] { "PostData_Id" });
            DropIndex("dbo.Comments", new[] { "PostId" });
            DropIndex("dbo.CommentDatas", new[] { "PostId" });
            DropTable("dbo.ReplyDatas");
            DropTable("dbo.PostDatas");
            DropTable("dbo.Replies");
            DropTable("dbo.Comments");
            DropTable("dbo.Posts");
            DropTable("dbo.CommentDatas");
        }
    }
}
