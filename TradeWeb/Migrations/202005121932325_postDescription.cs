namespace TradeWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class postDescription : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "PostDescription", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "PostDescription");
        }
    }
}
