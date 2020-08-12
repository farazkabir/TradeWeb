namespace TradeWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Nmedia : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Media",
                c => new
                    {
                        MediaId = c.String(nullable: false, maxLength: 128),
                        Id = c.Int(nullable: false),
                        FilePath = c.String(),
                    })
                .PrimaryKey(t => t.MediaId);
            
            AddColumn("dbo.Users", "MediaId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Users", "MediaId");
            AddForeignKey("dbo.Users", "MediaId", "dbo.Media", "MediaId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "MediaId", "dbo.Media");
            DropIndex("dbo.Users", new[] { "MediaId" });
            DropColumn("dbo.Users", "MediaId");
            DropTable("dbo.Media");
        }
    }
}
