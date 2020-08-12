namespace TradeWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testuser : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Users");
            AlterColumn("dbo.Users", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Users", "UserId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Users", "UserId");
            CreateIndex("dbo.Users", "UserId");
            AddForeignKey("dbo.Users", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Users", new[] { "UserId" });
            DropPrimaryKey("dbo.Users");
            AlterColumn("dbo.Users", "UserId", c => c.String());
            AlterColumn("dbo.Users", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Users", "Id");
        }
    }
}
