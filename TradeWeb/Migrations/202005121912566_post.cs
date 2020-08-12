namespace TradeWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class post : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        PostId = c.String(nullable: false, maxLength: 128),
                        CoverId = c.String(),
                        Category = c.String(),
                        UserId = c.String(),
                        Media_MediaId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.PostId)
                .ForeignKey("dbo.Media", t => t.Media_MediaId)
                .Index(t => t.Media_MediaId);
            
            AddColumn("dbo.Media", "PostId", c => c.String());
            AddColumn("dbo.Users", "Post_PostId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Users", "Post_PostId");
            AddForeignKey("dbo.Users", "Post_PostId", "dbo.Posts", "PostId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "Media_MediaId", "dbo.Media");
            DropForeignKey("dbo.Users", "Post_PostId", "dbo.Posts");
            DropIndex("dbo.Users", new[] { "Post_PostId" });
            DropIndex("dbo.Posts", new[] { "Media_MediaId" });
            DropColumn("dbo.Users", "Post_PostId");
            DropColumn("dbo.Media", "PostId");
            DropTable("dbo.Posts");
        }
    }
}
