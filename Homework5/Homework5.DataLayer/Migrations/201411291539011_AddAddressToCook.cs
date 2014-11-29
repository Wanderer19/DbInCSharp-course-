namespace Homework5.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAddressToCook : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Men", "Address", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Men", "Address");
        }
    }
}
