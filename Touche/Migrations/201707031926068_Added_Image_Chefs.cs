namespace Touche.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_Image_Chefs : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Chefs", "Image", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Chefs", "Image");
        }
    }
}
