namespace Ef.codeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCityBookReleationship : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Covers", "Id", "dbo.Books");
            DropForeignKey("dbo.EmpBooks", "Fk_bookId", "dbo.Books");
            DropPrimaryKey("dbo.Books");
            AlterColumn("dbo.Books", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Books", "Id");
            CreateIndex("dbo.Books", "Id");
            AddForeignKey("dbo.Books", "Id", "dbo.City", "Id");
            AddForeignKey("dbo.Covers", "Id", "dbo.Books", "Id");
            AddForeignKey("dbo.EmpBooks", "Fk_bookId", "dbo.Books", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmpBooks", "Fk_bookId", "dbo.Books");
            DropForeignKey("dbo.Covers", "Id", "dbo.Books");
            DropForeignKey("dbo.Books", "Id", "dbo.City");
            DropIndex("dbo.Books", new[] { "Id" });
            DropPrimaryKey("dbo.Books");
            AlterColumn("dbo.Books", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Books", "Id");
            AddForeignKey("dbo.EmpBooks", "Fk_bookId", "dbo.Books", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Covers", "Id", "dbo.Books", "Id");
        }
    }
}
