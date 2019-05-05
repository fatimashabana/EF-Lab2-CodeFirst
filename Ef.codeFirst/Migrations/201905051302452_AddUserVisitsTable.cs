namespace Ef.codeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserVisitsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserVisits",
                c => new
                    {
                        Fk_CityId = c.Int(nullable: false),
                        Fk_UserId = c.Int(nullable: false),
                        When = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.Fk_CityId, t.Fk_UserId })
                .ForeignKey("dbo.Cities", t => t.Fk_CityId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.Fk_UserId, cascadeDelete: true)
                .Index(t => t.Fk_CityId)
                .Index(t => t.Fk_UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserVisits", "Fk_UserId", "dbo.Users");
            DropForeignKey("dbo.UserVisits", "Fk_CityId", "dbo.Cities");
            DropIndex("dbo.UserVisits", new[] { "Fk_UserId" });
            DropIndex("dbo.UserVisits", new[] { "Fk_CityId" });
            DropTable("dbo.Users");
            DropTable("dbo.UserVisits");
        }
    }
}
