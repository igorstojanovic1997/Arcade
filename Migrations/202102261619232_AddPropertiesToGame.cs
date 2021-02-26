namespace Arcade.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPropertiesToGame : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Games", "Genre", c => c.String());
            AddColumn("dbo.Games", "ReleaseDate", c => c.DateTime());
            AddColumn("dbo.Games", "DateAdded", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Games", "DateAdded");
            DropColumn("dbo.Games", "ReleaseDate");
            DropColumn("dbo.Games", "Genre");
        }
    }
}
