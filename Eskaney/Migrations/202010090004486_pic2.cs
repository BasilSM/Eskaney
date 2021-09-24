namespace Eskaney.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pic2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Pictures", "Housing_ID", "dbo.Housings");
            DropIndex("dbo.Pictures", new[] { "Housing_ID" });
            DropColumn("dbo.Pictures", "Housing_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pictures", "Housing_ID", c => c.Int(nullable: false));
            CreateIndex("dbo.Pictures", "Housing_ID");
            AddForeignKey("dbo.Pictures", "Housing_ID", "dbo.Housings", "ID", cascadeDelete: true);
        }
    }
}
