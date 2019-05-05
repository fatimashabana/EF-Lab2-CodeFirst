namespace Ef.codeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditCountryAndCityTable : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Cities", newName: "City");
            RenameTable(name: "dbo.Countries", newName: "Country");
            RenameColumn(table: "dbo.City", name: "countryId", newName: "Fk_CountryId");
            RenameIndex(table: "dbo.City", name: "IX_countryId", newName: "IX_Fk_CountryId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.City", name: "IX_Fk_CountryId", newName: "IX_countryId");
            RenameColumn(table: "dbo.City", name: "Fk_CountryId", newName: "countryId");
            RenameTable(name: "dbo.Country", newName: "Countries");
            RenameTable(name: "dbo.City", newName: "Cities");
        }
    }
}
