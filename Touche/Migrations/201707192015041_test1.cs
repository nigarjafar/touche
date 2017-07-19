namespace Touche.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MenuItems", "Category_Id", "dbo.Categories");
            DropIndex("dbo.MenuItems", new[] { "Category_Id" });
            AddColumn("dbo.MenuItems", "Category_Id1", c => c.Int());
            AlterColumn("dbo.MenuItems", "Category_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.MenuItems", "Category_Id1");
            AddForeignKey("dbo.MenuItems", "Category_Id1", "dbo.Categories", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MenuItems", "Category_Id1", "dbo.Categories");
            DropIndex("dbo.MenuItems", new[] { "Category_Id1" });
            AlterColumn("dbo.MenuItems", "Category_Id", c => c.Int());
            DropColumn("dbo.MenuItems", "Category_Id1");
            CreateIndex("dbo.MenuItems", "Category_Id");
            AddForeignKey("dbo.MenuItems", "Category_Id", "dbo.Categories", "Id");
        }
    }
}
