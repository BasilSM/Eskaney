namespace Eskaney.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pic1 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Pictures", name: "Apatrment_ID", newName: "Apartment_ID");
            RenameIndex(table: "dbo.Pictures", name: "IX_Apatrment_ID", newName: "IX_Apartment_ID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Pictures", name: "IX_Apartment_ID", newName: "IX_Apatrment_ID");
            RenameColumn(table: "dbo.Pictures", name: "Apartment_ID", newName: "Apatrment_ID");
        }
    }
}
