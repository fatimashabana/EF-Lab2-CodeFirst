namespace Ef.codeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCityCountryRelationship5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cities", "country_Id1", "dbo.Countries");
            DropIndex("dbo.Cities", new[] { "country_Id1" });
            RenameColumn(table: "dbo.Cities", name: "country_Id1", newName: "countryId");
            AlterColumn("dbo.Cities", "countryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Cities", "countryId");
            AddForeignKey("dbo.Cities", "countryId", "dbo.Countries", "Id", cascadeDelete: true);
            DropColumn("dbo.Cities", "country_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cities", "country_Id", c => c.Int(nullable: false));
            DropForeignKey("dbo.Cities", "countryId", "dbo.Countries");
            DropIndex("dbo.Cities", new[] { "countryId" });
            AlterColumn("dbo.Cities", "countryId", c => c.Int());
            RenameColumn(table: "dbo.Cities", name: "countryId", newName: "country_Id1");
            CreateIndex("dbo.Cities", "country_Id1");
            AddForeignKey("dbo.Cities", "country_Id1", "dbo.Countries", "Id");
        }
    }
}
