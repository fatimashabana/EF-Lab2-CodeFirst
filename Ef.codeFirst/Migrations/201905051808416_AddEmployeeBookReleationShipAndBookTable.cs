namespace Ef.codeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEmployeeBookReleationShipAndBookTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EmpBooks",
                c => new
                    {
                        Fk_EmployeeId = c.Int(nullable: false),
                        Fk_bookId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Fk_EmployeeId, t.Fk_bookId })
                .ForeignKey("dbo.Employee", t => t.Fk_EmployeeId)
                .ForeignKey("dbo.Books", t => t.Fk_bookId)
                .Index(t => t.Fk_EmployeeId)
                .Index(t => t.Fk_bookId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmpBooks", "Fk_bookId", "dbo.Books");
            DropForeignKey("dbo.EmpBooks", "Fk_EmployeeId", "dbo.Employee");
            DropIndex("dbo.EmpBooks", new[] { "Fk_bookId" });
            DropIndex("dbo.EmpBooks", new[] { "Fk_EmployeeId" });
            DropTable("dbo.EmpBooks");
            DropTable("dbo.Books");
        }
    }
}
