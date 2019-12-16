namespace Assignment_NET.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createOrder3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderInformations", "PaymentType", c => c.Int(nullable: false));
            DropColumn("dbo.OrderInformations", "OrderId");
            DropColumn("dbo.OrderInformations", "PaymentTypeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderInformations", "PaymentTypeId", c => c.Int(nullable: false));
            AddColumn("dbo.OrderInformations", "OrderId", c => c.Int(nullable: false));
            DropColumn("dbo.OrderInformations", "PaymentType");
        }
    }
}
