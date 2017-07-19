namespace Touche.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_required : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Reviews", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Reviews", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Reviews", "Text", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Reviews", "Text", c => c.String());
            AlterColumn("dbo.Reviews", "Email", c => c.String());
            AlterColumn("dbo.Reviews", "Name", c => c.String());
        }
    }
}
