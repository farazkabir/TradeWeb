namespace TradeWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class categoryname : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "CategoryName", c => c.String());
            DropColumn("dbo.Posts", "Category");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "Category", c => c.String());
            DropColumn("dbo.Posts", "CategoryName");
        }
    }
}
