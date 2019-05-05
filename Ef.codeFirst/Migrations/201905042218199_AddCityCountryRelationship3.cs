namespace Ef.codeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCityCountryRelationship3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cities", "country_Id", c => c.Int());
            CreateIndex("dbo.Cities", "country_Id");
            AddForeignKey("dbo.Cities", "country_Id", "dbo.Countries", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cities", "country_Id", "dbo.Countries");
            DropIndex("dbo.Cities", new[] { "country_Id" });
            DropColumn("dbo.Cities", "country_Id");
        }
    }
}
