namespace TradeWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class namerequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Name", c => c.String());
        }
    }
}
