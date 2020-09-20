namespace TradeWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Review : DbMigration
    {
        public override void Up()
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
            
            AddColumn("dbo.Comments", "Timestamp", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comments", "Timestamp");
            DropTable("dbo.Reviews");
        }
    }
}
