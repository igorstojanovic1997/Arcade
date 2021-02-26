using System.Web.UI.WebControls;

namespace Arcade.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateBirthDate : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET Birthdate = '11/11/1991' Where Id=1");
            Sql("UPDATE Customers SET Birthdate = '05/02/1996' Where Id=2");

        }

        public override void Down()
        {
        }
    }
}
