namespace Touche.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDeleteOnCascase_1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MenuItems", "Category_Id", "dbo.Categories");
            AddColumn("dbo.MenuItems", "Category_Id1", c => c.Int());
            CreateIndex("dbo.MenuItems", "Category_Id1");
            AddForeignKey("dbo.MenuItems", "Category_Id1", "dbo.Categories", "Id");
            AddForeignKey("dbo.MenuItems", "Category_Id", "dbo.Categories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MenuItems", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.MenuItems", "Category_Id1", "dbo.Categories");
            DropIndex("dbo.MenuItems", new[] { "Category_Id1" });
            DropColumn("dbo.MenuItems", "Category_Id1");
            AddForeignKey("dbo.MenuItems", "Category_Id", "dbo.Categories", "Id");
        }
    }
}
