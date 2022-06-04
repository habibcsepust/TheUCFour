namespace TheUCFour.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Name = c.String(),
                        ReorderLevel = c.Double(nullable: false),
                        Description = c.String(),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: false)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Name = c.String(),
                        Address = c.String(),
                        Email = c.String(),
                        Contact = c.String(),
                        LoyalityPoint = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PurchaseDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        AvailableQuantity = c.Double(nullable: false),
                        ManufactureDate = c.String(),
                        ExpireDate = c.String(),
                        Remarks = c.String(),
                        Quantity = c.Double(nullable: false),
                        UnitPrice = c.Double(nullable: false),
                        TotalPrice = c.Double(nullable: false),
                        PreviousUnitPrice = c.Double(nullable: false),
                        PreviousMRP = c.Double(nullable: false),
                        MRP = c.Double(nullable: false),
                        PurchaseId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: false)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: false)
                .ForeignKey("dbo.Purchases", t => t.PurchaseId, cascadeDelete: false)
                .Index(t => t.PurchaseId)
                .Index(t => t.ProductId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Purchases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        InvoiceNo = c.String(),
                        SupplierId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Suppliers", t => t.SupplierId, cascadeDelete: false)
                .Index(t => t.SupplierId);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Name = c.String(),
                        Address = c.String(),
                        Email = c.String(),
                        Contact = c.String(),
                        ContactPerson = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SaleDetials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Single(nullable: false),
                        AvailableQuantity = c.Int(nullable: false),
                        MRP = c.Single(nullable: false),
                        TotalMRP = c.Single(nullable: false),
                        SaleId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Sales", t => t.SaleId, cascadeDelete: true)
                .Index(t => t.SaleId)
                .Index(t => t.ProductId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Date = c.DateTime(nullable: false),
                        GrandTotal = c.Single(nullable: false),
                        Discount = c.Single(nullable: false),
                        DiscountAmount = c.Single(nullable: false),
                        PayableAmount = c.Single(nullable: false),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SaleDetials", "SaleId", "dbo.Sales");
            DropForeignKey("dbo.Sales", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.SaleDetials", "ProductId", "dbo.Products");
            DropForeignKey("dbo.SaleDetials", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Purchases", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.PurchaseDetails", "PurchaseId", "dbo.Purchases");
            DropForeignKey("dbo.PurchaseDetails", "ProductId", "dbo.Products");
            DropForeignKey("dbo.PurchaseDetails", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Sales", new[] { "CustomerId" });
            DropIndex("dbo.SaleDetials", new[] { "CategoryId" });
            DropIndex("dbo.SaleDetials", new[] { "ProductId" });
            DropIndex("dbo.SaleDetials", new[] { "SaleId" });
            DropIndex("dbo.Purchases", new[] { "SupplierId" });
            DropIndex("dbo.PurchaseDetails", new[] { "CategoryId" });
            DropIndex("dbo.PurchaseDetails", new[] { "ProductId" });
            DropIndex("dbo.PurchaseDetails", new[] { "PurchaseId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropTable("dbo.Sales");
            DropTable("dbo.SaleDetials");
            DropTable("dbo.Suppliers");
            DropTable("dbo.Purchases");
            DropTable("dbo.PurchaseDetails");
            DropTable("dbo.Customers");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
