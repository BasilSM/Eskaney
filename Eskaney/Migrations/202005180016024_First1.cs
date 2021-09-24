namespace Eskaney.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First1 : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Housings", t => t.Housing_ID, cascadeDelete: true)
                .Index(t => t.Housing_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Labour_Wages", "Housing_ID", "dbo.Housings");
            DropIndex("dbo.Labour_Wages", new[] { "Housing_ID" });
            DropTable("dbo.Labour_Wages");
        }
    }
}
