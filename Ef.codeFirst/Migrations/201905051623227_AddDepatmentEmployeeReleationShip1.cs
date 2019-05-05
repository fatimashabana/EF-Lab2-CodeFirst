namespace Ef.codeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDepatmentEmployeeReleationShip1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employee", "Department_DeptId", "dbo.Department");
            DropColumn("dbo.Employee", "Fk_DepartmentId");
            RenameColumn(table: "dbo.Employee", name: "Department_DeptId", newName: "Fk_DepartmentId");
            RenameIndex(table: "dbo.Employee", name: "IX_Department_DeptId", newName: "IX_Fk_DepartmentId");
            AddForeignKey("dbo.Employee", "Fk_DepartmentId", "dbo.Department", "DeptId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employee", "Fk_DepartmentId", "dbo.Department");
            RenameIndex(table: "dbo.Employee", name: "IX_Fk_DepartmentId", newName: "IX_Department_DeptId");
            RenameColumn(table: "dbo.Employee", name: "Fk_DepartmentId", newName: "Department_DeptId");
            AddColumn("dbo.Employee", "Fk_DepartmentId", c => c.Int(nullable: false));
            AddForeignKey("dbo.Employee", "Department_DeptId", "dbo.Department", "DeptId", cascadeDelete: true);
        }
    }
}
