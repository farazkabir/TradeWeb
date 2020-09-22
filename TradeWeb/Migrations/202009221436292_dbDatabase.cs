namespace TradeWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbDatabase : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Posts", "TradeDemands");
            DropTable("dbo.Comments");
            DropTable("dbo.Reviews");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        ReviewId = c.String(nullable: false, maxLength: 128),
                        Content = c.String(),
                        ReviewerId = c.String(),
                        UserId = c.String(),
                        Timestamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ReviewId);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentId = c.String(nullable: false, maxLength: 128),
                        Content = c.String(),
                        PostId = c.String(),
                        UserId = c.String(),
                        Timestamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CommentId);
            
            AddColumn("dbo.Posts", "TradeDemands", c => c.String());
        }
    }
}
