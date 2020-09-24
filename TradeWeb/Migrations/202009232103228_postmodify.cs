namespace TradeWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class postmodify : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "PostTitle", c => c.String());
            AddColumn("dbo.Posts", "Timestamp", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "Timestamp");
            DropColumn("dbo.Posts", "PostTitle");
        }
    }
}
