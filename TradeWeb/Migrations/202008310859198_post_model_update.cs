namespace TradeWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class post_model_update : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "TradeDemands", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "TradeDemands");
        }
    }
}
