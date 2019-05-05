namespace Ef.codeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDepatmentEmployeeReleationShip : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employee", "Fk_DepartmentId", c => c.Int(nullable: false));
            AddColumn("dbo.Employee", "Department_DeptId", c => c.Int(nullable: false));
            CreateIndex("dbo.Employee", "Department_DeptId");
            AddForeignKey("dbo.Employee", "Department_DeptId", "dbo.Department", "DeptId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employee", "Department_DeptId", "dbo.Department");
            DropIndex("dbo.Employee", new[] { "Department_DeptId" });
            DropColumn("dbo.Employee", "Department_DeptId");
            DropColumn("dbo.Employee", "Fk_DepartmentId");
        }
    }
}
