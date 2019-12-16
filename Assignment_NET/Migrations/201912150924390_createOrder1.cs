namespace Assignment_NET.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createOrder1 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.OrderInformations");
            AddColumn("dbo.OrderInformations", "OrderId", c => c.Int(nullable: false));
            AlterColumn("dbo.OrderInformations", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.OrderInformations", "Id");
            CreateIndex("dbo.OrderInformations", "Id");
            AddForeignKey("dbo.OrderInformations", "Id", "dbo.Orders", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderInformations", "Id", "dbo.Orders");
            DropIndex("dbo.OrderInformations", new[] { "Id" });
            DropPrimaryKey("dbo.OrderInformations");
            AlterColumn("dbo.OrderInformations", "Id", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.OrderInformations", "OrderId");
            AddPrimaryKey("dbo.OrderInformations", "Id");
        }
    }
}
