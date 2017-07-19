namespace Touche.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test11 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MenuItems", "Category_Id1", "dbo.Categories");
            DropIndex("dbo.MenuItems", new[] { "Category_Id1" });
            DropColumn("dbo.MenuItems", "Category_Id");
            RenameColumn(table: "dbo.MenuItems", name: "Category_Id1", newName: "Category_Id");
            AlterColumn("dbo.MenuItems", "Category_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.MenuItems", "Category_Id");
            AddForeignKey("dbo.MenuItems", "Category_Id", "dbo.Categories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MenuItems", "Category_Id", "dbo.Categories");
            DropIndex("dbo.MenuItems", new[] { "Category_Id" });
            AlterColumn("dbo.MenuItems", "Category_Id", c => c.Int());
            RenameColumn(table: "dbo.MenuItems", name: "Category_Id", newName: "Category_Id1");
            AddColumn("dbo.MenuItems", "Category_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.MenuItems", "Category_Id1");
            AddForeignKey("dbo.MenuItems", "Category_Id1", "dbo.Categories", "Id");
        }
    }
}
