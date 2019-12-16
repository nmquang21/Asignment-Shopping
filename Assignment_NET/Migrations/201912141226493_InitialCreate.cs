namespace Assignment_NET.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                        Image = c.String(),
                        Description = c.String(),
                        Gender = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        Categoty_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Categoty_Id)
                .Index(t => t.Categoty_Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        RollNumber = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Email = c.String(),
                        Image = c.String(),
                        Status = c.Int(nullable: false),
                        Note = c.String(),
                        Birthday = c.DateTime(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.RollNumber);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Categoty_Id", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "Categoty_Id" });
            DropTable("dbo.Students");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
