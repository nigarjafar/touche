namespace Touche.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class name_to_image_slider : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sliders", "Image", c => c.String());
            DropColumn("dbo.Sliders", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sliders", "Name", c => c.String());
            DropColumn("dbo.Sliders", "Image");
        }
    }
}
