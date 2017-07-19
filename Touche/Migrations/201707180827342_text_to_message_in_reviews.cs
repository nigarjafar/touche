namespace Touche.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class text_to_message_in_reviews : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reviews", "Message", c => c.String(nullable: false));
            DropColumn("dbo.Reviews", "Text");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reviews", "Text", c => c.String(nullable: false));
            DropColumn("dbo.Reviews", "Message");
        }
    }
}
