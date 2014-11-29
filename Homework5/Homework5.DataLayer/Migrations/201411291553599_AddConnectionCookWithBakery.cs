namespace Homework5.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddConnectionCookWithBakery : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Men", "BakeryId", c => c.Int());
            CreateIndex("dbo.Men", "BakeryId");
            AddForeignKey("dbo.Men", "BakeryId", "dbo.Bakeries", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Men", "BakeryId", "dbo.Bakeries");
            DropIndex("dbo.Men", new[] { "BakeryId" });
            DropColumn("dbo.Men", "BakeryId");
        }
    }
}
