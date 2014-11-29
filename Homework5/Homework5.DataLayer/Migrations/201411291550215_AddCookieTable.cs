namespace Homework5.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCookieTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cookies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Taste = c.Int(nullable: false),
                        Color = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Cookies");
        }
    }
}
