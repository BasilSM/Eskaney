namespace Eskaney.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Labour_Wages", "Housing_ID", "dbo.Housings");
            DropIndex("dbo.Labour_Wages", new[] { "Housing_ID" });
            DropTable("dbo.Labour_Wages");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Labour_Wages",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Parson_Name = c.String(nullable: false),
                        Labour_Name = c.String(nullable: false),
                        Parson_Phone = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Coust = c.Double(nullable: false),
                        Notes = c.String(),
                        Housing_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateIndex("dbo.Labour_Wages", "Housing_ID");
            AddForeignKey("dbo.Labour_Wages", "Housing_ID", "dbo.Housings", "ID", cascadeDelete: true);
        }
    }
}
