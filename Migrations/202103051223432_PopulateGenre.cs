using System.Web.UI.WebControls;

namespace Arcade.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenre : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Name) VALUES ('Action')");
            Sql("INSERT INTO Genres (Name) VALUES ('Adventure')");
            Sql("INSERT INTO Genres (Name) VALUES ('Racing')");
            Sql("INSERT INTO Genres (Name) VALUES ('MMORPG')");

        }

        public override void Down()
        {
        }
    }
}
