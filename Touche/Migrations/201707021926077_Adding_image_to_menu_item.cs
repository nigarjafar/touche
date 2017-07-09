namespace Touche.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Adding_image_to_menu_item : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MenuItems", "Image", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MenuItems", "Image");
        }
    }
}
