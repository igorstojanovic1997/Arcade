namespace Arcade.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyAnnotationsToGame : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Games", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Games", "Name", c => c.String());
        }
    }
}
